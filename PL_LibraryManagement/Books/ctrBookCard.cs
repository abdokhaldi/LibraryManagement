using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL_LibraryManagement.Books
{
     partial class ctrBookCard : UserControl
    {
        BookService _SelectedBook;
        public event Action AddBookFormAdded;
        public event Action<BookService> EditBookFormAdded;
        public event Action BookCardClosed;
        public event Action BooksListRefereshed;
        public event Action<bool> CardInfoStripeEnabled;
        public ctrBookCard(BookService SelectedBook)
        {
            InitializeComponent();
            _SelectedBook = SelectedBook;
            SetupUI();
            this.Width = this.Width -10;
            this.Load += CardControlLoad;
        }

        private void SetupUI()
        {
            gbCard.TitleColor = AppColors.ButtonText;
            gbCard.TitleFont = AppFonts.GbText;
            gbCard.BackColor = AppColors.Primary;
            gbCard.BorderColor = gbCard.BackColor;
            plCard.BackColor = AppColors.Background;
            gbCard.Padding = new Padding(5, 20, 5, 5);
            plButons.BackColor = AppColors.Primary;
            this.BackColor = AppColors.Primary;
            btnClose.BackColor = AppColors.Danger;
            UIConfigurator.SetupCardLabels(plCard,"lbl");
        }
        private void AddBookImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                PictureBox pb = new PictureBox();
                pb.ImageLocation = imagePath;
                //pb.Dock = DockStyle.Fill;
                pb.Size = new Size(plImage.Width-1, plImage.Height-1);
                pb.BackgroundImageLayout = ImageLayout.Zoom;

                plImage.Controls.Add(pb);
            }
        }

        private void LoadBookData()
        {
            lblTitle.Text = _SelectedBook.Title;
            lblBookID.Text = _SelectedBook.BookID.ToString();
            lblPublisher.Text = _SelectedBook.Publisher;
            lblYearPublisher.Text = _SelectedBook.YearPublished;
            lblCategory.Text = _SelectedBook.CategoryInfo.CategoryName;
            lblAuthor.Text = _SelectedBook.Author;
            lblQuantity.Text = _SelectedBook.Quantity.ToString(); 
            lblStatus.Text = _SelectedBook.IsActive ? "Active" : "Inactive";

            string fullPath = ImageProcessorService.GetFullImagePath(_SelectedBook.ImagePath);
            
            AddBookImage(fullPath);
            SetupActiveButton();
        }
        public void RefreshCard()
        {
            LoadBookData();
        }
        private void SetupActiveButton()
        {
            if (_SelectedBook.IsActive)
            {
                btnActive.BackColor = AppColors.Danger;
                btnActive.Text = "Deactivate";
            }
            else
            {
                btnActive.BackColor = AppColors.Success;
                btnActive.Text = "Activate";
            }
        }

        private void CardControlLoad(object sender , EventArgs e)
        {
            LoadBookData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            BookCardClosed?.Invoke();
            CardInfoStripeEnabled?.Invoke(true);
        }

        private void btnAddBookForm_Click(object sender, EventArgs e)
        {
            AddBookFormAdded?.Invoke();
        }

        
        private void btnActive_Click(object sender, EventArgs e)
        {
            if (_SelectedBook.IsActive)
            {
              OperationResultBLL result = BookService.DeactivateBook(_SelectedBook);
                if (result.Success)
                {
                    MessageBox.Show(result.Message);
                    _SelectedBook.IsActive = false;
                }
            }else
            {
                OperationResultBLL result = BookService.ActivateBook(_SelectedBook);
                if (result.Success)
                {
                    MessageBox.Show(result.Message);
                    _SelectedBook.IsActive = true;
                }
            }
            BooksListRefereshed?.Invoke();
            LoadBookData();
            SetupActiveButton();
        }

        

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            EditBookFormAdded?.Invoke(_SelectedBook);
        }
    }
}

using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//using static System.Net.Mime.MediaTypeNames;

namespace PL_LibraryManagement.Books
{
    public partial class ctrAddEditBook : UserControl
    {
        private BookService _BookSelected;
        public delegate void EventHandler();
        public event EventHandler OnFormClosed;
        private enum Mode {Add=1,Update=2 }
        private Mode _Mode = Mode.Add;
       
        public ctrAddEditBook(BookService book=null)
        {
            HandleLoadingMode(book);
         }
       
        private void HandleLoadingMode(BookService book)
        {
            if (book == null) {
                InitializeComponent();
                AppColors.SetupGroupBoxFormUI(gbForm, "Add :");
               
                SetupPanelFormUI();
                LoadCategories();
                _Mode = Mode.Add;
            }
            else
            {
                InitializeComponent();
               AppColors.SetupGroupBoxFormUI(gbForm,"Update :");
                SetupPanelFormUI();
                LoadCategories();
                FillFormFields(book);
                this.Margin = new Padding(10, 10, 10, 10);
                _BookSelected = book;
                _Mode = Mode.Update;
            }
        }

        private void  OnCloseForm()
        {
            EventHandler handler = OnFormClosed;
            if (handler != null)
            {
                handler();
            }
        }
        

        private void LoadCategories()
        {
            List<CategoryService> categories = CategoryService.GetAllCategories();
            cmbCaterory.Items.Clear();
            cmbCaterory.DataSource = categories;
            cmbCaterory.DisplayMember = "CategoryName";
            cmbCaterory.ValueMember = "CategoryID";
        }
        


    
        private void FillFormFields(BookService book)
        {
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtPublisher.Text = book.Publisher;
            txtYearPublished.Text = book.YearPublished;
            txtQuantity.Text = book.Quantity.ToString();
            chkIsActive.Checked = book.IsActive;
            cmbCaterory.SelectedValue = book.CategoryID;
            string fullPath = ImageProcessorService.GetFullImagePath(book.ImagePath);
            ShowImageInPanel(fullPath);
        }

        private void SetupPanelFormUI()
        {
            plForm.BackColor = AppColors.Background;
            chkIsActive.Font = AppFonts.Button;
            btnClose.BackColor = AppColors.Danger;
            btnSave.BackColor = AppColors.Accent;
            btnClose.Font = AppFonts.Button;
            btnSave.Font = AppFonts.Button;
            UIConfigurator.SetupTextBoxesUI(plForm);
                
        }
        
        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCloseForm();
        }

       

        
private Image LoadImageSafely(string fullPath)
    {
        if (string.IsNullOrEmpty(fullPath) || !File.Exists(fullPath))
        {
            return null; 
        }

        try
        {
            byte[] imageBytes = File.ReadAllBytes(fullPath);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error loading image: {ex.Message}");
            return null;
        }
    }
    private void ShowImageInPanel(string filePath)
        {
           
            var existing = plImage.Controls.OfType<PictureBox>().FirstOrDefault();
            if (existing != null)
            {
               var img = existing.Image;

                existing.Image = null;
                plImage.Controls.Remove(existing);
                existing.Dispose();

                img?.Dispose();
            }


            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.Zoom; // يحافظ على نسبة العرض/الارتفاع
            pb.BorderStyle = BorderStyle.None;
          
            

           
            using (var img = LoadImageSafely(filePath))
            {
                if (img == null) return;
                pb.Image = new Bitmap(img);
                pb.ImageLocation = filePath;
            }
            pb.Size = new Size(plImage.Width-1, plImage.Height-1);
            plImage.Controls.Add(pb);
        }
        private void UpdateRemoveLink()
        {
            lnkRemoveImage.Enabled = plImage.Controls.OfType<PictureBox>().Any();
            lnkRemoveImage.Visible = lnkRemoveImage.Enabled; // أو اتركه دائماً مرئياً لكن معطل
        }

        private void lnkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemoveImageFromPanel();
            UpdateRemoveLink();
        }
        private void RemoveImageFromPanel()
        {
            var existing = plImage.Controls.OfType<PictureBox>().FirstOrDefault();
            if (existing != null)
            {
               var img = existing.Image;

                existing.Image = null;
                plImage.Controls.Remove(existing);
                existing.Dispose();

                img?.Dispose();
            }
        }
        private string GetImagePath()
        {
            var existing = plImage.Controls.OfType<PictureBox>().FirstOrDefault();
            if (existing != null && existing.ImageLocation != "")
                return existing.ImageLocation;

            return "";
        }
        private void AddBook(BookService book)
        {
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Publisher = txtPublisher.Text;
            book.YearPublished = txtYearPublished.Text;
            book.Quantity = Convert.ToInt32(txtQuantity.Text);
            book.CategoryID = Convert.ToInt32(cmbCaterory.SelectedValue);
            book.IsActive = chkIsActive.Checked;
            book.ImagePath = "";
            string selectedFilePath = GetImagePath();

            if (File.Exists(selectedFilePath))
            {
                book.ImageBytesToSave = File.ReadAllBytes(selectedFilePath);
            }
            else
            {
                book.ImageBytesToSave = null;
            }
        }
        private void UpdateBook(BookService book)
        {
            AddBook(book);
        }

        private void Save()
        {
            BookService book = null;
            switch (_Mode)
            {
                case Mode.Add:
                    book = new();
                    AddBook(book);
                    break;
                case Mode.Update:
                    book = _BookSelected;
                    UpdateBook(book);
                    break;
            }
            OperationResultBLL result = book.Save();
            OperationMessage(result,book);
        }
        private void OperationMessage(OperationResultBLL result,BookService book)
        {
            
            if (result.Success)
            {
                MessageBox.Show(result.Message);
                if (_Mode == Mode.Add)
                {
                    _Mode = Mode.Update;
                    _BookSelected = book;
                    gbForm.Text = "Update :";
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void lklblAddImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select image";
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = ofd.FileName;

                    ShowImageInPanel(selectedPath);
                    UpdateRemoveLink();
                }
            }
        }
    }
}

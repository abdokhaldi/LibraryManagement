using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PL_LibraryManagement.People.UserControls
{
    public partial class ctrBooksList : UserControl
    {
        private List<BookService> _booksList;

        public event Action<BookService> BookSelected;
        public event Action<BookService> EditBookFormAdded;
        public event Action AddBookFormAdded;
        
        public ctrBooksList()
        {
            InitializeComponent();
            
            dgvBooks.DefaultCellStyle.Font = AppFonts.Button;
            dgvBooks.ColumnHeadersDefaultCellStyle.Font = AppFonts.Button;
            dgvBooks.ColumnHeadersHeight = 35;
            dgvBooks.RowTemplate.Height = 30;
            SetupUI();
            LoadBooks();
        }

        private void SetupUI()
        {
            lblTitle.Text = "Books";
            AppColors.SetupDataGridViewUI(dgvBooks);
            panel1.Padding = new Padding(10, 10, 10, 10);
            pnlTop.BackColor = AppColors.Background;
            lblTitle.ForeColor = AppColors.Primary;
            lblTitle.Font = AppFonts.Title;
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            txtSearch.Font = AppFonts.Normal;
            lblSearch.Font = AppFonts.Normal;
        }
        
        private void CreateDataGridColumns(DataGridView dataGridView)
        {
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvBooks.AutoGenerateColumns = false;
           // dgvBooks.Dock = DockStyle.Fill;
            if (dgvBooks.Columns.Count == 0)
            {
                var columns = new Dictionary<string, (string, int)>
                {
                    ["Title40"] = ("Title",0),
                    ["Author30"] = ("Author", 0),
                    ["Publisher15"] = ("Publisher", 0),
                    ["YearPublished"] = ("YearPublished", 150),
                    ["Category15"] = ("Category", 0),
                    ["IsActive"] = ("Active", 100)
                   };

                UIConfigurator._CreateColumns(dgvBooks, columns);
            }
        }


        public void RefereshBooksList()
        {
            LoadBooks();
        }
        private void LoadBooks()
        {
            dgvBooks.DataSource = null;


            CreateDataGridColumns(dgvBooks);

            dgvBooks.ContextMenuStrip = contextMenuStrip2;

             _booksList = BookService.GetAllBooks();

            dgvBooks.DataSource = _booksList;

           // dgvBooks.CellFormatting += FormattingDataGridValue;
        }

        
        private bool AutoFilterSearchBy(string query, string value)
        {
            return (value != null && value.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private  List<BookService> FilterBooksList(string query)
        {
           return _booksList.Where(b =>

               AutoFilterSearchBy(query, b.Title)
            || AutoFilterSearchBy(query, b.Author)
             ).ToList();
        }
        private void searchTimer_Tick(object sender, System.EventArgs e)
        {
            searchTimer.Stop();
            string query = txtSearch.Text.Trim();

            var foundBooks = FilterBooksList(query);

            dgvBooks.DataSource = foundBooks;
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void dgvBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBooks.Columns[e.ColumnIndex].DataPropertyName == "IsActive")
            {
                if (e.Value is bool value)
                {
                    e.Value = value ? "Yes" : "No";
                }
            }
        }

        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
              var selectedBook = (BookService)dgvBooks.SelectedRows[0].DataBoundItem;
              BookSelected?.Invoke(selectedBook);
              cardInfoToolStripMenuItem.Enabled = false;
        }

        private void cardInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var selectedBook = (BookService)dgvBooks.SelectedRows[0].DataBoundItem;
                BookSelected?.Invoke(selectedBook);
                cardInfoToolStripMenuItem.Enabled = false;
            }
        }

        public void ActiveCardInfoToolStripMenuItem(bool active)
        {
            cardInfoToolStripMenuItem.Enabled = active;

        }

       
        private void addStripMenuItem1_Click(object sender, EventArgs e)
        {

            AddBookFormAdded?.Invoke();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bookSelected = (BookService)dgvBooks.SelectedRows[0].DataBoundItem;
            EditBookFormAdded?.Invoke(bookSelected);
        }
    }
   
}

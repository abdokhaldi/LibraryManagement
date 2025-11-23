using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PL_LibraryManagement.Borrowings
{
    public partial class ctrManageBorrowings : UserControl
    {
        public event Action BorrowingCardAdded;
        public event Action<int> BorrowingCanceled;
        public event Action<int,DateTime> EditCardAdded;
        public ctrManageBorrowings()
        {
            InitializeComponent();
            dgvBorrowings.RowHeadersVisible = false;
            AppColors.SetupDataGridViewUI(dgvBorrowings);
            UIConfigurator.ConfigureDataGridView(dgvBorrowings);
            lblTitle.ForeColor = AppColors.Primary;
            lblTitle.Font = AppFonts.Title;
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            LoadBorrowings();

        }

        private void CreateColumns()
        {
            dgvBorrowings.AutoGenerateColumns = false;
            if (dgvBorrowings.Columns.Count == 0)
            {

                var columns = new Dictionary<string, (string, int)>
                {
                    
                    ["Title65"] = ("Title", 0),
                    ["FullName35"] = ("Full Name", 0),
                    ["BorrowingDate"] = ("Borrowing Date", 150),
                    ["DueDate"] = ("Due Date", 150),
                    ["ReturnDate"] = ("Return Date", 150),
                    ["Status"] = ("Status", 100),
                };
                UIConfigurator.CreateColumns(dgvBorrowings, columns);
            }
        }
        private void LoadBorrowings()
        {
            
            dgvBorrowings.Dock = DockStyle.Fill;
            dgvBorrowings.Columns.Clear();
            
            CreateColumns();
            dgvBorrowings.ContextMenuStrip = contextMenuStrip2;
            dgvBorrowings.DataSource = BorrowingInfoService.GetAllBorrowingsInfo(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BorrowingCardAdded?.Invoke();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowingInfoService selectedBorrowing = (BorrowingInfoService)dgvBorrowings.SelectedRows[0].DataBoundItem;
            
            if (selectedBorrowing == null)
            {
                MessageBox.Show("Please select an item firs and try again.","No item selected",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if (selectedBorrowing.ReturnDate != null)
            {
                MessageBox.Show("You cannot change inactivated borrowing due date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            EditCardAdded?.Invoke(selectedBorrowing.BorrowingID,selectedBorrowing.DueDate);
        }

        private void deactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrowingInfoService selectedBorrowing = (BorrowingInfoService)dgvBorrowings.SelectedRows[0].DataBoundItem;
            if (dgvBorrowings.SelectedRows.Count == 0) return;
            if (selectedBorrowing == null) return;

            OperationResultBLL result = BorrowingService.CancelBorrowing(selectedBorrowing.BorrowingID, selectedBorrowing.BookID);
            if (result.Success)
            {
                MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addStripMenuItem1_Click(object sender, EventArgs e)
        {
            BorrowingCardAdded?.Invoke();
        }
    }
}

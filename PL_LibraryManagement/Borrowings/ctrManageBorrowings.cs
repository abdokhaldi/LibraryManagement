using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.Borrowings
{
    public partial class ctrManageBorrowings : UserControl
    {
        public ctrManageBorrowings()
        {
            InitializeComponent();
            AppColors.SetupDataGridViewUI(dgvBorrowings);
            UIConfigurator.ConfigureDataGridView(dgvBorrowings);
            LoadBorrowings();

        }

        private void CreateColumns()
        {
            dgvBorrowings.AutoGenerateColumns = false;
            if (dgvBorrowings.Columns.Count == 0)
            {

                var columns = new Dictionary<string, (string, int)>
                {
                    ["BorrowingID"] = ("Borrowing ID", 130),
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
            dgvBorrowings.DataSource = BorrowingInfoService.GetAllBorrowingsInfo(); 

        }



    }
}

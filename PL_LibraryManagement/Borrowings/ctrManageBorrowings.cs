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
            
            LoadBorrowings();

        }
        private void CreateColumns()
        {

            var columns = new Dictionary<string, (string, int)>
            {
                ["BorrowingID"] = ("Borrowing ID",150),
                ["Title70"] = ("Title",0),
                ["FullName30"] = ("Full Name",0),
                ["BorrowingDate"] = ("Borrowing Date",150),
                ["DueDate"] = ("Due Date",150),
               // ["ReturnDate"] = ("Return Date",150),
                ["Status"] = ("Status",100),
            };
            UIConfigurator.CreateColumns(dgvBorrowings,columns);
        }
     private void LoadBorrowings()
        {

            dgvBorrowings.Columns.Clear();
            CreateColumns();
            dgvBorrowings.DataSource = BorrowingInfoService.GetAllBorrowingsInfo(); 

        }



    }
}

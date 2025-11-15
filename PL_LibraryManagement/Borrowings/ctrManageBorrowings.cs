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

     private void LoadBorrowings()
        {
            dgvBorrowings.Columns.Clear();

            dgvBorrowings.DataSource = BorrowingInfoService.GetAllBorrowingsInfo(); 

        }



    }
}

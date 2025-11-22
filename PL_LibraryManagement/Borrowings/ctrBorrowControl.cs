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
    public partial class ctrBorrowControl : UserControl
    {
        private int _SelectedBookID = 0;
        private int _SelectedPersonID = 0;
        
        public ctrBorrowControl()
        {
            InitializeComponent();
            AppColors.SetupGroupBoxFormUI(gbBorrow, "Add :");
           
            SetupLoading();

            AttachEvents();
        }

        private void SetupLoading()
        {
            
            this.plBorrow.BackColor = Color.White;
            btnBorrow.BackColor = AppColors.Accent;
            btnCancel.BackColor = AppColors.Danger;
            plBorrow.Padding = new Padding(10, 30, 10, 10);
            this.Height = 300;
            this.Width = 700;
            dtDueDate.Value = DateTime.Now.AddDays(7);
        }
        private void AttachEvents()
        {
            ctrBookLookUP1.SelectedBookIDShared -= ReceiveSelectedBookID;
            ctrBookLookUP1.SelectedBookIDShared += ReceiveSelectedBookID;

            ctrPersonLookUp.SelectedBorrowerIDShared -= ReceiveSelectedBorrowerID;
            ctrPersonLookUp.SelectedBorrowerIDShared += ReceiveSelectedBorrowerID;

        }
        private void ReceiveSelectedBookID(int bookID)
        {
            
                _SelectedBookID = bookID;
        }
        private void ReceiveSelectedBorrowerID(int personID)
        {
            
            _SelectedPersonID = personID;
        }


        private void ctrLookUpControl1_Load(object sender, EventArgs e)
        {

        }
        private DialogResult Message(string entityName)
        {
           return MessageBox.Show($"Please select {entityName} and try again!");

        }
        private void btnBorrow_Click(object sender, EventArgs e)
        {

            Save();
        }
        private void AddBorrowing(BorrowingService borrowing) {
            if (_SelectedBookID <= 0)
            {
                Message("book");
                return;
            }
            if (_SelectedPersonID <= 0)
            {
                Message("borrower");
                return;
            }
            
            borrowing.BookID =   _SelectedBookID;
            borrowing.PersonID = _SelectedPersonID;
            borrowing.DueDate = dtDueDate.Value;
        }
        
        private void Save()
        {
            BorrowingService borrowing = new BorrowingService();
            AddBorrowing(borrowing);
            OperationResultBLL result = borrowing.Save();
            if (result.Success)
            {
                MessageBox.Show(result.Message);
            }
            else { MessageBox.Show(result.Message); }
            
        }

    }
}

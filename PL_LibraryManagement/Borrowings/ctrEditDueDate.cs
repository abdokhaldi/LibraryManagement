using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Windows.Forms;

namespace PL_LibraryManagement.Borrowings
{
    public partial class ctrEditDueDate : UserControl
    {
        private int _SelectedBorrowingID = 0;
        public event Action BorrowingListExtended;
        public ctrEditDueDate(int borrowingID,DateTime currentDueDate)
        {
            InitializeComponent();
            _SelectedBorrowingID = borrowingID;
            dtDueDate.MinDate = currentDueDate;
            flwPanelDueDate.Padding = new Padding(5,20,5,5);
            AppColors.SetupGroupBoxFormUI(cgbDueDate,"Extend due date:");
            flwPanelDueDate.BackColor = AppColors.Background;
            
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_SelectedBorrowingID <= 0)
            {
                MessageBox.Show("Please select an item and try again.","No item selected",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure to change due date?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                OperationResultBLL result = BorrowingService.EditDueDate(_SelectedBorrowingID, dtDueDate.Value);
                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    BorrowingListExtended?.Invoke();
                    return;
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            BorrowingListExtended?.Invoke();
        }
    }
}

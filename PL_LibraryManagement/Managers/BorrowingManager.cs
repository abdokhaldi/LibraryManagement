using PL_LibraryManagement.Borrowings;
using PL_LibraryManagement.UI_Theme;
using System.Windows.Forms;

namespace PL_LibraryManagement.Managers
{
    internal class BorrowingManager
    {
       private Panel _MainPanel;

        private ctrManageBorrowings _ManageBorrowingList ;
        ctrBorrowControl _BorrowControl;
        public BorrowingManager(Panel mainPanel)
        {
            _MainPanel = mainPanel;
            _ManageBorrowingList = new ctrManageBorrowings();
            _BorrowControl = new ctrBorrowControl();
        }

        public void ShowBorrowingList()
        {
            if (_MainPanel != null)
                _MainPanel.Controls.Clear();
            _ManageBorrowingList.Dock = DockStyle.Fill;
            
            _MainPanel.Controls.Add(_ManageBorrowingList);
            AttachEvents();
        }
         private void AttachEvents()
        {
            _ManageBorrowingList.BorrowCardAdded -= AddBorrowControl;
            _ManageBorrowingList.BorrowCardAdded += AddBorrowControl;
        }

        private void AddBorrowControl()
        {
            if (_MainPanel.Contains(_BorrowControl))
            {
                return;
            }
            _ManageBorrowingList.Dock = DockStyle.Top;
            CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter,_MainPanel, _BorrowControl);
            _MainPanel.Controls.Add(_BorrowControl);
        }
    }
}

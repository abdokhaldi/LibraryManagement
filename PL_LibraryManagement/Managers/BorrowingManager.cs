using BLL_LibraryManagement;
using PL_LibraryManagement.Borrowings;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PL_LibraryManagement.Managers
{
    internal class BorrowingManager
    {
       private Panel _MainPanel;

        private ctrManageBorrowings _ManageBorrowingList ;
        ctrBorrowControl _BorrowingControl;
        ctrEditDueDate _EditBorrowingControl;

        
        public BorrowingManager(Panel mainPanel)
        {
            _MainPanel = mainPanel;
            _ManageBorrowingList = new ctrManageBorrowings();
            _BorrowingControl = new ctrBorrowControl();
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
            _ManageBorrowingList.BorrowingCardAdded -= AddBorrowingControl;
            _ManageBorrowingList.BorrowingCardAdded += AddBorrowingControl;

            _ManageBorrowingList.EditCardAdded -= EditBorrowingControl;
            _ManageBorrowingList.EditCardAdded += EditBorrowingControl;

        }

        private void AddBorrowingControl()
        {
            if (_MainPanel.Contains(_EditBorrowingControl))
                _EditBorrowingControl.Dispose();

            if (_MainPanel.Contains(_BorrowingControl))
            {
                _MainPanel.Controls.Remove(_BorrowingControl);
                
                _BorrowingControl.Dispose();
            }
              _BorrowingControl = new ctrBorrowControl();

            _ManageBorrowingList.Dock = DockStyle.Top;
            CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter,_MainPanel, _BorrowingControl);
            _MainPanel.Controls.Add(_BorrowingControl);
            AttachBorrowingEvents();
        }
        private void ExtendBorrowingList()
        {
            _ManageBorrowingList.Dock = DockStyle.Fill;
        }
        private void AttachEditBorrowingEvents()
        {
            _EditBorrowingControl.BorrowingListExtended -= ExtendBorrowingList;
            _EditBorrowingControl.BorrowingListExtended += ExtendBorrowingList;

        }

        private void AttachBorrowingEvents()
        {
            _BorrowingControl.BorrowingListExtended -= ExtendBorrowingList;
            _BorrowingControl.BorrowingListExtended += ExtendBorrowingList;
        }
        private void EditBorrowingControl(int borrowingID,DateTime currentDueDate)
        {
            if (_MainPanel.Contains(_BorrowingControl))
                _BorrowingControl.Dispose();

            if (_MainPanel.Contains(_EditBorrowingControl))
            {
                _MainPanel.Controls.Remove(_EditBorrowingControl);
                
                _EditBorrowingControl.Dispose();
            }
            _EditBorrowingControl = new ctrEditDueDate(borrowingID, currentDueDate);

            _ManageBorrowingList.Dock = DockStyle.Top;
            CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _EditBorrowingControl);
            _MainPanel.Controls.Add(_EditBorrowingControl);
        }
    }
}

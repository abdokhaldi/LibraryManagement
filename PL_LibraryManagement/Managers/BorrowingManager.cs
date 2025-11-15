using PL_LibraryManagement.Borrowings;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.Managers
{
    internal class BorrowingManager
    {
       private Panel _MainPanel;

        private ctrManageBorrowings _ManageBorrowingList ;
        public BorrowingManager(Panel mainPanel)
        {
            _MainPanel = mainPanel;
            _ManageBorrowingList = new ctrManageBorrowings();
        }

        public void ShowBorrowingList()
        {
            if (_MainPanel != null)
                _MainPanel.Controls.Clear();
            _ManageBorrowingList.Dock = DockStyle.Fill;
            
            _MainPanel.Controls.Add(_ManageBorrowingList);

        }



    }
}

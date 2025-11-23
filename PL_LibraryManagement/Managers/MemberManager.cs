using PL_LibraryManagement.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.Managers
{
    internal class MemberManager
    {
        private ctrMembers _MembersControl;
        private Panel _MainPanel;
        internal MemberManager(Panel mainPanel)
        {
            _MainPanel = mainPanel;
            _MembersControl = new ctrMembers();
        }

        public void ShowMembersList()
        {
            if (_MainPanel != null)
                _MainPanel.Controls.Clear();
            _MembersControl.Dock = DockStyle.Fill;

            _MainPanel.Controls.Add(_MembersControl);
            
        }
    }
}

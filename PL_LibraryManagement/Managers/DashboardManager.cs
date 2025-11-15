using PL_LibraryManagement.DashBoard;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.Managers
{
    public class DashboardManager
    {
       private Panel _MainPanel;
       private ctrStatistics _StatisticsControl;
       private ctrRecentActivities _RecentActivitiesControl;
        public DashboardManager(Panel mainPanel)
        {
            _MainPanel = mainPanel;
            _StatisticsControl = new ctrStatistics();
            _RecentActivitiesControl = new ctrRecentActivities();
        }

        private void AddStatisticsToPanel()
        {
            _MainPanel.Controls.Clear();
           _StatisticsControl.Dock = DockStyle.Top;
            _MainPanel.Controls.Add(_StatisticsControl);
        }

        private void AddActivitiesToMainPanel()
        {
            _RecentActivitiesControl.Size = new Size(_MainPanel.Width - 30, _MainPanel.Height / 2);
            _RecentActivitiesControl.Dock = DockStyle.Bottom;
            _MainPanel.Controls.Add(_RecentActivitiesControl);
        }
        public void AddControlsToMainPanel()
        {
            _MainPanel.Controls.Clear();
            AddStatisticsToPanel();
            AddActivitiesToMainPanel();
        }
    }
}

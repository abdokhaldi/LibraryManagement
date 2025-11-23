using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Windows.Forms;

namespace PL_LibraryManagement.DashBoard
{
    public partial class ctrRecentActivities : UserControl
    {
        public ctrRecentActivities()
        {
            InitializeComponent();
            dgvRecentActivities.RowHeadersVisible = false;
            AppColors.SetupDataGridViewUI(dgvRecentActivities);
            UIConfigurator.ConfigureDataGridView(dgvRecentActivities);
           // gbActivities.ForeColor = AppColors.Background;
            gbActivities.BackColor = AppColors.Primary;
            this.Load += (s, e) => LoadActivities();
            
        }

        private void CreateColumns()
        {
            dgvRecentActivities.AutoGenerateColumns = false;
            if (dgvRecentActivities.Columns.Count == 0)
            {
             var  columns = new Dictionary<string, (string, int)>{ 
                    ["ActivityType"]= ("Activity Type",200),
                    ["Description99"] = ("Description", 0),
                    ["Username"]    = ("Username", 150),
                    ["CreatedAt"]   = ("Created At", 200),
                    ["EntityName"]  = ("Entity Name", 120),
                    ["EntityID"]    = ("Entity ID", 100),
                };
            
            UIConfigurator.CreateColumns(dgvRecentActivities, columns);
        }
     }
        
        private void LoadActivities()
        {
            var list = ActivityService.GetAllActivities();
            CreateColumns();
            dgvRecentActivities.DataSource = null;

            if (list == null) return;
            dgvRecentActivities.DataSource = list;

          }

        private void gbActivities_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = (GroupBox)sender;
            e.Graphics.Clear(box.BackColor);

            using (Brush textBrush = new SolidBrush(AppColors.Background))
            {
                SizeF textSize = e.Graphics.MeasureString(box.Text, box.Font);
                e.Graphics.DrawString(box.Text,box.Font,textBrush,10,0);
            }
        }
    }
}

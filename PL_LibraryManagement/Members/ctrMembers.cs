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

namespace PL_LibraryManagement.Members
{
    public partial class ctrMembers : UserControl
    {
        public ctrMembers()
        {
            InitializeComponent();

            dgvMembers.RowHeadersVisible = false;
            UIConfigurator.ConfigureDataGridView(dgvMembers);
            AppColors.SetupDataGridViewUI(dgvMembers);
            lblTitle.ForeColor = AppColors.Primary;
            lblTitle.Font = AppFonts.Title;
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            LoadMembers();
        }
        private void CreateColumns()
        {
            dgvMembers.AutoGenerateColumns = false;
            if (dgvMembers.Columns.Count == 0)
            {

                var columns = new Dictionary<string, (string, int)>
                {

                    ["MemberID25"] = ("Member ID", 0),
                    ["PersonID25"] = ("PersonID", 0),
                    ["JoinDate25"] = ("Join Date", 0),
                    ["IsActive25"] = ("Is Active", 0),
                    
                };
                UIConfigurator.CreateColumns(dgvMembers, columns);
            }
        }
        private void LoadMembers()
        {

            dgvMembers.Dock = DockStyle.Fill;
            dgvMembers.Columns.Clear();

            CreateColumns();
            dgvMembers.ContextMenuStrip = contextMenuStrip2;
            dgvMembers.DataSource = MemberService.GetAllMembers();

        }
    }
}

using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PL_LibraryManagement.Users.UserControls
{
    public partial class ctrUsersList : UserControl
    {
        public event Action UserAddFormAdded;
        public event Action<UserService> UserCardAdded;
        public event Action<UserService> UserUpdateFormAdded;

        private int _SelectedUserID = 0;
        public ctrUsersList()
        {
            InitializeComponent();
            UIConfigurator.ConfigureDataGridView(dgvUsers);
            AppColors.SetupDataGridViewUI(dgvUsers);
            
            this.Load -= ctrUsersList_Load;
            this.Load += ctrUsersList_Load;
        }
        private void CreateColumns()
        {
            dgvUsers.Columns.Clear();
            dgvUsers.AutoGenerateColumns = false;
            Dictionary<string, (string, int)> columns = new()
            {
                ["FullName"] = ("Full Name",200),
                ["Username"] = ("Username", 100),
                ["Phone40"] = ("Phone", 0),
                ["Email40"] = ("Email", 0),
                ["RoleName"] = ("Role Name", 100),
                ["IsActive"] = ("Is Active", 100),
                ["CreatedAt20"] = ("Join Date", 0),
            };
            UIConfigurator.CreateColumns(dgvUsers,columns);
        }
        public void ReloadInfo()
        {
            ctrUsersList_Load(null,null);
        }
        private void ctrUsersList_Load(object sender , EventArgs e)
        {
            dgvUsers.DataSource = null;
            var users = UserService.GetAllUsers();
               if(users != null)
               
            CreateColumns();
            dgvUsers.DataSource = users ;
            dgvUsers.CellFormatting += FormattingDataGridValue;
        }
        private void FormattingDataGridValue(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvUsers.Columns[e.ColumnIndex].DataPropertyName == "IsActive")
            {
                if (e.Value is bool value)
                {
                    e.Value = value ? "Yes" : "No";

                    e.FormattingApplied = true;
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAddFormAdded?.Invoke();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedUser = (UserService)dgvUsers.SelectedRows[0].DataBoundItem; 
           
            if (selectedUser != null)
            {         
                UserCardAdded?.Invoke(selectedUser);
                cardInfoToolStripMenuItem.Enabled = false;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedUser = (UserService)dgvUsers.SelectedRows[0].DataBoundItem;
            if (selectedUser != null)
            {
                UserUpdateFormAdded?.Invoke(selectedUser);

                cardInfoToolStripMenuItem.Enabled = false;
            }
        }

        private void desactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedUser =(UserService) dgvUsers.SelectedRows[0].DataBoundItem;
            if (selectedUser == null) return;
            if(selectedUser.IsActive)
            {
                if (UserService.DesactiveUser(selectedUser.UserID))
                {
                    activeToolStripMenuItem.Text = "Activate";
                }
            }
            else
            {
                if (UserService.ActivateUser(selectedUser.UserID))
                {
                    activeToolStripMenuItem.Text = "Deactivate";
                }
            }
            ReloadInfo();
        }
    }
}

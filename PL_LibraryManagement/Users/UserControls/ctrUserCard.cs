using BLL_LibraryManagement;
using Microsoft.SqlServer.Server;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL_LibraryManagement.Users.UserControls
{
     partial class ctrUserCard : UserControl
    {
        UserService _SelectedUser;
        public event Action CardClosed;
        public event Action<UserService> UpdateFormAdded;
        public event Action AddFormAdded;
        public event Action ControlRefereshed;
        public ctrUserCard(UserService user)
        {
            InitializeComponent();
            this.Height = this.Height +40;
            this.Width = this.Width+20 ;
            SetupCardItems();
            _SelectedUser = user;
            LoadUserInfo();
        }



        private void SetupCardItems()
        {
            AppColors.SetupGroupBoxFormUI(gbForm, "User Card :");
            this.tbForm.BackColor = AppColors.Background;
            UIConfigurator.SetupCardLabels(tbForm, "lbl");
            //UIConfigurator.SetupCardLabels(tbForm, "lab", AppFonts.GbText, AppColors.Primary);
            btnClose.BackColor = AppColors.Danger;
        }
        public void ReloadCardInfo()
        {
            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            if (_SelectedUser == null) return;
            lblUserID.Text = _SelectedUser.UserID.ToString();
            lblFullName.Text = _SelectedUser.FullName;
            lblUsername.Text = _SelectedUser.Username;
            lblPhone.Text = _SelectedUser.Phone;
            lblEmail.Text = _SelectedUser.Email;
            lblRoleName.Text = _SelectedUser.RoleName;
            lblJoinDate.Text = _SelectedUser.CreatedAt.ToString();
            lblIsActive.Text = _SelectedUser.IsActive ? "Yes" : "No";
        }

        
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            CardClosed?.Invoke();
        }

      

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateFormAdded?.Invoke(_SelectedUser);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFormAdded?.Invoke();
        }
        private void ChangeButtonAppearance(Button btn,string text,Color color)
        {
            btn.BackColor = color;
            btn.Text = text;
        }
       
        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (_SelectedUser == null) return;
            if (_SelectedUser.IsActive)
            {
               if( UserService.DesactiveUser(_SelectedUser.UserID))
                ChangeButtonAppearance(btnActivate,"Activate",Color.Green);
               MessageBox.Show("User deactivated .");
                _SelectedUser.IsActive = false;
            }
            else { 
            
             if (UserService.ActivateUser(_SelectedUser.UserID))
               
                ChangeButtonAppearance(btnActivate, "Deactivate", Color.Red);
               MessageBox.Show("User activated");
                _SelectedUser.IsActive = true;
            }
            
            ControlRefereshed?.Invoke();
         }
    }      
}

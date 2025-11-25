using BLL_LibraryManagement;
using PL_LibraryManagement.People.Forms;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL_LibraryManagement.Users.UserControls
{
     partial class ctrAddUpdateUser : UserControl
    {
        UserService _SelectedUser = null;
        public event Action AddUpdateFormClosed;
        private enum Mode {Add,Update }
        private Mode _Mode = Mode.Add;
        public ctrAddUpdateUser(UserService user=null)
        {
            InitializeComponent();
            this.Height = this.Height + 23;
            this.Width = this.Width+5;
            if(user==null)
            {
                _Mode = Mode.Add;
            }else
            {
                _Mode = Mode.Update;
                _SelectedUser = user;
                
                btnSelectPerson.Visible = false;
            }
                
            SetupForm(user);
            if(user!= null) { 
            LoadUserInfo(_SelectedUser);
            }
            LoadRoles();
        }

        private void SetupForm(UserService user)
        {
            bool isNull = (user == null);

            AppColors.SetupGroupBoxFormUI(gbForm, isNull ? "Add:" : "Update");
            this.tbForm.BackColor = AppColors.Background;

            btnSave.BackColor = AppColors.Accent;
            btnClose.BackColor = AppColors.Danger;
            btnSelectPerson.BackColor = Color.Blue;
            UIConfigurator.SetupCardLabels(tbForm, "lbl");
           // UIConfigurator.SetupCardLabels(tbForm, "lab", AppFonts.Button, AppColors.Primary);
            UIConfigurator.SetupTextBoxesUI(tbForm);
        }

        private void LoadUserInfo(UserService user)
        {
            
            lblUserID.Text = user.UserID.ToString();
            txtUsername.Text = user.Username;
            txtPassword.Text = "password";
            lblPersonID.Text = user.PersonID.ToString();
            chkIsActive.Enabled = user.IsActive;
        }
        private void FillUserService(UserService user)
        {
          
            user.Username = txtUsername.Text;
            user.PersonID = Convert.ToInt32(lblPersonID.Text);
            user.Password = txtPassword.Text;
            user.RoleID = Convert.ToInt32(cbRoles.SelectedValue);
            user.CreatedAt = DateTime.Now;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UserService user;
            if(_Mode == Mode.Add)
            {
               user  = new UserService();
            }
            else
            {
                user = _SelectedUser;
            }

                FillUserService(user);
            OperationResultBLL result = user.Save();
            if (result.Success)
            {
                MessageBox.Show(result.Message,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblUserID.Text = user.UserID.ToString();
            }else
            {
                MessageBox.Show(result.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            AddUpdateFormClosed?.Invoke();
        }

        private void ReceiveSelectedPersonID(int personID)
        {
            lblPersonID.Text = personID.ToString();
        }
        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            frmPersonCard personCard = new frmPersonCard();
            personCard.SelectedPersonID -= ReceiveSelectedPersonID;
            personCard.SelectedPersonID += ReceiveSelectedPersonID;
            personCard.ShowDialog();
        }
        private void LoadRoles()
        {
            cbRoles.DataSource = null;
            var roles = RoleService.GetAllRoles();
            cbRoles.ValueMember = "RoleID";
            cbRoles.DisplayMember = "RoleName";
            cbRoles.DataSource = roles;
        }

        
    }
}

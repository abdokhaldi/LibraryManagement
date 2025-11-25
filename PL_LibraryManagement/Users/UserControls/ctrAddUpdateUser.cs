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
        UserService _SelectedUser;
        public event Action AddUpdateFormClosed;
        public ctrAddUpdateUser(UserService user=null)
        {
            InitializeComponent();
            this.Height = this.Height + 23;
            this.Width = this.Width+5;
            _SelectedUser = user;
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
            txtPassword.Text = user.Password;
            lblPersonID.Text = user.PersonID.ToString();
            chkIsActive.Enabled = user.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserService user = new UserService();
            user.Username = txtUsername.Text;
            user.PersonID = Convert.ToInt32(lblPersonID.Text);
            user.Password = txtPassword.Text;
            user.RoleID = Convert.ToInt32(cbRoles.SelectedValue);
            user.CreatedAt = DateTime.Now;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

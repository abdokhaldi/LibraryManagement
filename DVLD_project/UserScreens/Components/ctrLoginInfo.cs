using DVLD_BussinessLayer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.UserScreens.Components
{
    public partial class ctrLoginInfo : UserControl
    {
        public string lbl_UserID{
            set { lblUserID.Text = value; }
            get { return lblUserID.Text;  }
        }
        public string txt_UserName
        {
            set { txtUserName.Text = value; }
            get { return txtUserName.Text; }
        }
        public string txt_Password
        {
            set { txtPassword.Text = value; }
            get { return txtPassword.Text; }
        }
        public string txt_ConfirmPassword
        {
            set { txtConfirmPassword.Text = value; }
            get { return txtConfirmPassword.Text; }
        }
        public bool cb_IsActive
        {
            set { cbIsActive.Checked = value; }
            get { return cbIsActive.Checked; }
        }

        public ctrLoginInfo()
        {
            InitializeComponent();
        }

    private void txtUsername_Password_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox ;
            if (txtBox == txtUserName)
            {
                if (clsUser.CheckIfUsernameExisting(txtUserName.Text))
                {
                    errorProvider1.SetError(txtBox,"this username is already existing");
                    e.Cancel = true ;
                    return;
                  }
                errorProvider1.SetError(txtBox, "");
            }
            else if (txtBox == txtConfirmPassword)
            {
                if (txtConfirmPassword.Text != txtPassword.Text )
                {
                    errorProvider1.SetError(txtBox, "the password is incompatible");
                    e.Cancel = true;
                    return;
                }
                errorProvider1.SetError(txtBox, "");
            }
        }
    }
}

using DVLD_BussinessLayer.Users;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_project.UserScreens.Forms
{
    public partial class frmChangePassword : Form
    {
        private clsUser _userInfo;

        public frmChangePassword(clsUser user)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _userInfo = user;
            ctrUserInfo1.FillUserInformation(_userInfo);
        }

        
        private void ValidateTextBox(TextBox txtBox, CancelEventArgs e)
        {
            if (txtBox == txtCurrentPassword)
            {
                if (_userInfo.Password != txtBox.Text && !string.IsNullOrEmpty(txtCurrentPassword.Text))
                {
                    errorProvider1.SetError(txtBox, "The current password is wrong");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtBox, "");

                }
            }

            else if (txtBox == txtConfirmPassword)
            {
                if (txtBox.Text != txtNewPassword.Text)
                {
                    errorProvider1.SetError(txtBox, "Password is not compatible");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtBox, "");
                }
            }
        }
        
        private void txtBoxChangePassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            ValidateTextBox(txtBox,e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _userInfo.Password = txtNewPassword.Text;

            if (!string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                if (!string.IsNullOrEmpty(txtNewPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    if (_userInfo.ChangeUserPassword(_userInfo.UserID))
                    {
                        MessageBox.Show("Password was changed successfuly.");
                    }else
                    {
                        MessageBox.Show("The Password could not be changed!");
                    }
                }
                else
                {
                    MessageBox.Show("please fill all text fields to continue");
                }
            }
            else
            {
                   MessageBox.Show("please fill all text fields to continue");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}




    


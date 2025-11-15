using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Users;
using DVLD_project.UserScreens.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_project.UserScreens.Forms
{
    public partial class frm_ChangePassword : Form
    {
        private clsUser _user;

        public frm_ChangePassword(clsUser user)
        {
            InitializeComponent();
            _user = user;
            ctrUserInfo1.FillUserInformation(user);
        }

        // 
        private void ValidateTextBox(System.Windows.Forms.TextBox txtBox, CancelEventArgs e)
        {
            if (txtBox == txtCurrentPassword)
            {
                if (_user.Password != txtBox.Text && !string.IsNullOrEmpty(txtCurrentPassword.Text))
                {
                    errorProvider1.SetError(txtBox, "Current password is wrong");
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
            System.Windows.Forms.TextBox txtBox = sender as System.Windows.Forms.TextBox;
            ValidateTextBox(txtBox,e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _user.Password = txtNewPassword.Text;

            if (!string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                if (!string.IsNullOrEmpty(txtNewPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    if (_user.ChangeUserPassword(_user.UserID))
                    {
                        MessageBox.Show("Password changed successfuly");
                    }else
                    {
                        MessageBox.Show("Password not changed");
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
    }   
}




    


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
        public string lblUserID{
            get {  return _lblUserID.Text;  }
               
            set { _lblUserID.Text = value; }
            
        }
        public string txtUserName
        {   get { return _txtUserName.Text;}
            set { _txtUserName.Text = value; }
             
        }
        public string txtPassword
        {  get { return _txtPassword.Text; }
            set { _txtPassword.Text = value; }
            
        }
        public string txtConfirmPassword
        {
            get { return _txtConfirmPassword.Text; }

            set { _txtConfirmPassword.Text = value; }
            
        }
        public bool chbIsActive
        {   
            get { return _chbIsActive.Checked; }

            set { _chbIsActive.Checked = value; }
        }



        public ctrLoginInfo()
        {
            InitializeComponent();
        }
        private string _GetValidateErrorMessage(TextBox txtBox)
        {
           if (txtBox == _txtUserName)
            {
                if (int.TryParse(_lblUserID.Text, out int userID))
                {
                    if (string.IsNullOrWhiteSpace(_txtUserName.Text))
                    {
                        return "Please fill the username field to continue!";
                    }
                    return "";
                }
                else
                {
                    if (clsUser.CheckIfUsernameExisting(_txtUserName.Text))
                    {
                        return "this username is already existing!";
                    }
                    else if(string.IsNullOrWhiteSpace(_txtUserName.Text))
                    {
                        return "the field is empty!";
                    }
                    return "";
                }
            }
            else if (txtBox == _txtPassword)
            {
                if (string.IsNullOrWhiteSpace(_txtPassword.Text))
                {
                    return "the password field can't be allowed with empty or whitespace!";
                }
                return "";
            }
            else if (txtBox == _txtConfirmPassword)
            {
                if (_txtConfirmPassword.Text != _txtPassword.Text)
                {
                    return "the password is incompatible";
                }
                return "";
            }
            return "";
        }


   

        public void LoadUserData( clsUser user)
        {
            if (user == null) return;

            _lblUserID.Text = user.UserID.ToString();
            _txtUserName.Text = user.UserName;
            _txtPassword.Text = user.Password;
            _txtConfirmPassword.Text = user.Password;
            _chbIsActive.Checked = user.IsActive;
        }

        private void _txtUserName_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            string errorMessage = _GetValidateErrorMessage(txtBox);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                errorProvider1.SetError(txtBox,errorMessage);
                e.Cancel = true;
                return;
            }
            errorProvider1.SetError(txtBox,errorMessage);
        }

    }
}

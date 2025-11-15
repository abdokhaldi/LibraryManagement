using DVLD_BussinessLayer.Users;
using System;
using System.Windows.Forms;
using DVLD_Project_v2.Global_Classes;

namespace DVLD_project.UserScreens
{
    public partial class frmLogin : Form
    {
       private string _filePath = "C:/Credentials_Store.Config/Credentials_store.txt";
        public frmLogin()
        {
            InitializeComponent();

            this.Load += frmLogin_load;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                txtUsername.Focus();
                return;
            }
             clsUser user = clsUser.FindUser("UserName", txtUsername.Text);
                if (user != null)
                {
                    // store credentials
                    clsCredincial.StoreCredentials(cbRememberMe.Checked,_filePath,user.UserName,user.Password);  //stores credential info if rememberMe is checked
                   
                    frmHomeScreen homeScreen = new frmHomeScreen(user);

                    clsSharedCurrentUserInfo.currentUserInfo.UserInfo = user;
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    cbRememberMe.Checked = false;
                    homeScreen.Show();

                }
                else
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Error : Incorrect username or password?";
                    txtPassword.Text = string.Empty;
                }
            
        }
    
    private void _GetCredentials()
        {
            string userName = "";
            string password = "";
            // get credentials with encoding password 
            clsCredincial.GetCredentials(_filePath,ref userName,ref password);
            txtUsername.Text = userName;
            txtPassword.Text = password;
        }
    private void frmLogin_load(object sender, EventArgs e)
    {
            // Get stored credentials
            _GetCredentials();
    }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        
    }
}


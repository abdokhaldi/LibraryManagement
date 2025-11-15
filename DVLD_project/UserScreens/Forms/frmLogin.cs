using DVLD_BussinessLayer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        private void _StoreCredentialInfo()
        {
            if (!File.Exists(_filePath))
            {
                using (var fs = File.Create(_filePath)) { } ;
            }
            if (cbRememberMe.Checked)
            {

                using (StreamWriter writer = new StreamWriter(_filePath, append: false))
                {
                    string hashedPassword = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(txtPassword.Text));
                    writer.WriteLine(txtUsername.Text);
                    writer.WriteLine(hashedPassword);
                }
            }
            else
            {
                File.WriteAllText(_filePath,string.Empty);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                if (clsUser.CheckForLogin(txtUsername.Text, txtPassword.Text))
                {

                    _StoreCredentialInfo();  //stores credential info if rememberMe is checked
                   
                    string username = txtUsername.Text;
                    frmHomeScreen homeScreen = new frmHomeScreen(username);

                    //clsSharedCurrentUserInfo.currentUserInfo.UserInfo = clsUser.FindUser("UserName", username);
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
        }
    
    private void _FillCredentialTxtBoxes()
        {
            string[] credentialLines = File.ReadAllLines(_filePath);
            if (File.Exists(_filePath))
            {
                if (credentialLines.Length == 2)
            {
                txtUsername.Text = credentialLines[0];
                    txtPassword.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(credentialLines[1]));
            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
            }

            }
            
        }
    private void frmLogin_load(object sender, EventArgs e)
    {
            _FillCredentialTxtBoxes();
    }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }
    }
}


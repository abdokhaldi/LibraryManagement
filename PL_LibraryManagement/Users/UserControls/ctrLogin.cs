using BLL_LibraryManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement
{
    public partial class ctrLogin : UserControl
    {
        public event Action LoginFormClosed;
        public event Action<OperationResultBLL> LoginResult;

        public ctrLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginFormClosed?.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
                return;

            OperationResultBLL loginResult = UserService.Login(username,password);
           
            if (!loginResult.Success)
            {
                lblErrorMessage.Text = loginResult.Message;
                return;
            }
            
            LoginResult?.Invoke(loginResult);
        }

        
    }
}

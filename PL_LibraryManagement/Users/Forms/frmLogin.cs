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

namespace PL_LibraryManagement.Users.Forms
{
    public partial class frmLogin : Form
    {
       
       private OperationResultBLL _OperationResult;
        public frmLogin()
        {
            InitializeComponent();
            this.Padding = new Padding(20,0,0,0);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ctrLogin1.LoginFormClosed += CloseLoginForm;
           
        }

        private void Login()
        {
           
        }
        private void CloseLoginForm()
        {
            
            this.Close();
            this.Dispose();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void ctrLogin1_LoginResult(OperationResultBLL obj)
        {
            _OperationResult = obj;
            if (_OperationResult.Success)
            {
               this.DialogResult = DialogResult.OK;
               
                return;
            }
            this.DialogResult = DialogResult.None;
         }
    }
}

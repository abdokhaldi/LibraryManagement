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

namespace DVLD_project.UserScreens.Forms
{

    public partial class frmUserDetails : Form
    {
        public frmUserDetails(clsUser userInfo)
        {
            InitializeComponent();
            ctrUserInfo1.FillUserInformation(userInfo);
      
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

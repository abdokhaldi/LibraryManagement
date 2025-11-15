using DVLD_BussinessLayer.Users;
using DVLD_project.People.Components;
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
    public partial class ctrUserInfo : UserControl
    {
       // public ctrPersonDetails ctr_PersonDetails
       // {
       //     get { return this.ctrPersonDetails1; }
       // }

        public ctrUserInfo()
        {
            InitializeComponent();
        }

        public void FillUserInformation(clsUser userInfo)
        {
          
            lblUserID.Text = userInfo.UserID.ToString();
            lblUsername.Text = userInfo.UserName;
            lblIsActive.Text = (userInfo.IsActive == true) ? "Yes":"No";
            ctrPersonDetails1.FillPersonInfo(userInfo.PersonID);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

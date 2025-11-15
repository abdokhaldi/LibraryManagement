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
        public ctrPersonDetails ctr_PersonDetails
        {
            get { return this.ctrPersonDetails1; }
        }

        public ctrUserInfo()
        {
            InitializeComponent();
        }

        public void FillUserInformation(clsUser user)
        {
            lblUserID.Text = user.UserID.ToString();
            lblUsername.Text = user.UserName;
            lblIsActive.Text = (user.IsActive == true) ? "Yes":"No";
        }
    }
}

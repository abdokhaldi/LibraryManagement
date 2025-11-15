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
        public frmUserDetails(clsUser user)
        {
            InitializeComponent();
            ctrUserInfo1.FillUserInformation(user);
        }
    }
}

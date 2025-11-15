using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.People.Forms
{
    
    public partial class frmPersonDetails : Form
    {
        
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ctrPersonDetails1.FillPersonInfo(personID);
            btnClose.Click += btnClose_Click;
        }
        public frmPersonDetails(string nationalNo)
        {
            InitializeComponent();
            //ctrPersonDetails1.FillPersonInfo("NationalNo", nationalNo);
            btnClose.Click += btnClose_Click;
        }

        private void btnClose_Click(object sender , EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {

        }
    }
}

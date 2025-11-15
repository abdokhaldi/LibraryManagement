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
            // ctrPersonDetails1.FillPersonInformation(personID);
           
        }
        public frmPersonDetails(string nationalNo)
        {
            InitializeComponent();
            //ctrPersonDetails1.FillPersonInformationForm("NationalNo", nationalNo);
           
        }

        

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

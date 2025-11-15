using System;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens.InternationalDriverLicense
{
    public partial class frmInternationalLicenseInfo : Form
    {
        int _internationalLicenseID = -1;
        public frmInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _internationalLicenseID = internationalLicenseID;
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrInternationalLicenseInfo1.LoadInternationalLicenseInfo(_internationalLicenseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

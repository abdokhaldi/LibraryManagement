using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.LicensClass;
using DVLD_BussinessLayer.UsifiedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        
       private clsLDLApplications _ldlApplicationInfo;
        private int _ldlApplicationID;
        private short _issueReason;
      
        public frmIssueDriverLicenseFirstTime(int ldlApplicationID, short issueReason)
        {
            InitializeComponent();
            _issueReason = issueReason;
            _ldlApplicationID = ldlApplicationID;
            
        }

        private void btnIssueLocalDrivingLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = _ldlApplicationInfo.IssueDrivingLicenseForFirstTime(this.txtNotes.Text.Trim(),clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserID);

            bool licenseIssued = (LicenseID!=-1);
           
            MessageHelper.ShowMessageResult(licenseIssued, "the License Issued For First Time", "Issue the license was failed");
            if (licenseIssued)
            {
                btnIssue.Enabled = false;
            }
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            this.txtNotes.Focus();
            _ldlApplicationInfo = clsLDLApplications.FindLocalDrivingLicenseApplicationByID(_ldlApplicationID);

            int LicenseID = _ldlApplicationInfo.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show("this person already has a license","Not allowed",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                this.Close();
                return;
            }
            
            ctrDLApplicationInfo1.FillDLApplicationInfo(_ldlApplicationInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }


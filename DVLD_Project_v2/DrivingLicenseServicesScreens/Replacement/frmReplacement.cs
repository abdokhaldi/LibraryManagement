
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.Replacement;
using DVLD_DataAccess.ApplicationTypes;
using DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications;
using System;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens
{
    public partial class frmReplacement : Form
    {

        private int _SelectedLicenseID = -1;
        public frmReplacement()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private int _GetApplicationType()
        {
            if (rbDamaged.Checked)
            {
                return 4;
            }
            else
            {
                return 3;
            }
        }

        private void frmReplacementForLost_Damaged_Load(object sender, EventArgs e)
        { 
            string username = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
            lklLicensesInfo.Enabled = false;
            lklLicensesHistory.Enabled = false;
            rbDamaged.Checked = true;
            lblAppDate.Text = DateTime.Now.ToString("dd-mm-yyyy");
            lblCreatedBy.Text = username;
        }

       

        private void lklLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
             frmLicenseHistory licenseHistory =
                  new frmLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
               licenseHistory.Show();
        }
           
      private void lklLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(_SelectedLicenseID);
            licenseInfo.Show();
        }

        private void ctrDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }


        short _IssueReason() {
            if (rbLost.Checked)
                return 3;
            else
                return 4;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
           if (!MessageHelper.SowMessageConform("Are you sure you want to replace this license?"))
            {
                MessageBox.Show("The replacement was Cancelled");
                return;
            }
           // issue replacement function with CreatorUser and issueReason     
            clsLicense newLicense = ctrDriverLicenseInfoWithFilter1.SelectedLicense.Replace(_IssueReason(),clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserID);
            // check if replacement succeeded
            bool success = (newLicense != null);
            if (success)
            {
                // then set new lblApplicationID and lblReplacementID with new saved 
                lblReplacedApplication.Text = newLicense.ApplicationID.ToString();
                lblReplacedLicenseID.Text = newLicense.LicenseID.ToString();
            }
            // then show success message else Fail message
            MessageHelper.ShowMessageResult(success,"The license is replaced successfully","The replacement is failed");
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblReplacementTitleForDamaged.Visible = true;
            lblReplacementTitleForLost.Visible = false;
            lblReplacementTitleForDamaged.Text = "Replacement For Damaged License";
            
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(_GetApplicationType()).ApplicationTypeFeese.ToString();

        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblReplacementTitleForLost.Visible = true;
            lblReplacementTitleForDamaged.Visible = false;

            lblReplacementTitleForLost.Text = "Replacement For Lost License";
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(_GetApplicationType()).ApplicationTypeFeese.ToString();
        }

        private void ctrDriverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            _SelectedLicenseID = obj;

            lblOldLicenseID.Text = _SelectedLicenseID.ToString();
            lklLicensesHistory.Enabled = true;
            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("The selected Licese is Not Active,try with another Active license!","Not Allowed");
                btnReplace.Enabled = false;
                return;

            }
            btnReplace.Enabled = true;
            gbReplacement.Enabled = false;
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
       }

        private void lblReplacement_LOGO_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

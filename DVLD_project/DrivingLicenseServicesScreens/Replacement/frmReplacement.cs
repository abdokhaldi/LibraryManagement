
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.Replacement;
using DVLD_DataAccess.ApplicationTypes;
using System;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens
{
    public partial class frmReplacement : Form
    {

        private int _SelectedLicense = -1;
        public frmReplacement()
        {
            InitializeComponent();
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
        //    string username = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
            lklLicensesInfo.Enabled = false;
            lklLicensesHistory.Enabled = false;
            rbDamaged.Checked = true;
            lblAppDate.Text = DateTime.Now.ToString("dd-mm-yyyy");
           // lblCreatedBy.Text = username;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void lklLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool isConverted = int.TryParse(lblOldLicenseID.Text, out int _isConverted);
            if (isConverted)
            {
                //frmLicenseHistory licenseHistory =
                   // new frmLicenseHistory(ctrDriverLicenseInfo1.lbl_NationalNo);
            //    licenseHistory.Show();
            }
            else
            {
                MessageBox.Show($"There is no Renewed license Issued for this license yet");
            }
            
        }

        private void lklLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(null, Convert.ToInt32(lblReplacedLicenseID.Text));
            //licenseInfo.Show();
        }

        private void ctrDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }

       private void FillReplacementLicenseObject(short issueReason, clsLicenseReplacement replacement, clsLicense License)
        {
            // application info
          //  replacement.Application.ApplicantPersonID = clsPerson.FindPerson("NationalNo", License.NationalNo).PersonID;
           // replacement.Application.ApplicationTypeID = _IssueReason();
           // replacement.Application.ApplicationDate = DateTime.Now;
           // replacement.Application.ApplicationStatus = 3;
           // replacement.Application.LastStatusDate = DateTime.Now;
           // replacement.Application.PaidFees = Convert.ToDouble(lblApplicationFees.Text);
           // replacement.Application.CreatedByUserID = Convert.ToInt32(lblCreatedBy.Text);

            // License info
        //    replacement.LicenseID = License.LicenseID;
        //    replacement.DriverID = License.DriverID;
        //    replacement.IssueDate = DateTime.Now;
        //    replacement.LicenseClassID = clsLicenseClass.FindLicenseClassID(License.ClassName);
        //    replacement.ExpirationDate = License.ExpirationDate;
        //    replacement.Notes = License.Notes;
          //  replacement.PaidFees = License.PaidFees + replacement.Application.PaidFees;
        //    replacement.IssueReason = _IssueReason();
       //     replacement.ImagePath = License.ImagePath;
        //    replacement.IsActive = true;

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
//            clsLicense newLicense = ctrDriverLicenseInfoWithFilter1.SelectedLicense.Replace(_IssueReason(),clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserID);
            // check if replacement succeeded
         //   bool success = (newLicense != null);
            /*if (success)
            {
                // then set new lblApplicationID and lblReplacementID with new saved 
                lblReplacedApplication.Text = newLicense.ApplicationID.ToString();
                lblReplacedLicenseID.Text = newLicense.LicenseID.ToString();
            }*/
            // then show success message else Fail message
          //  MessageHelper.ShowMessageResult(success,"The license is replaced successfully","The replacement is failed");
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblReplacement_LOGO.Text = "Replacement For Damaged License";
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(_GetApplicationType()).ApplicationTypeFeese.ToString();

        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblReplacement_LOGO.Text = "Replacement For Lost License";
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(_GetApplicationType()).ApplicationTypeFeese.ToString();
        }

        private void ctrDriverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            _SelectedLicense = obj;

            lblOldLicenseID.Text = _SelectedLicense.ToString();
            lklLicensesHistory.Enabled = true;
            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("The selected Licese is Not Active,try with another Active license!","Not Allowed");
                btnIssueReplacement.Enabled = false;
                return;

            }
            btnIssueReplacement.Enabled = true;
            gbReplacement.Enabled = false;
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;

        }
    }
}

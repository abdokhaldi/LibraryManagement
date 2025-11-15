using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.Users;
using DVLD_BussinessLayer.UsifiedModels;
using DVLD_DataAccess.ApplicationTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens.InternationalDriverLicense
{
    public partial class frmInternationalDriverLicenseApplication : Form
    {
        private int _SelectedLicenseID=-1;
        private int _CurrentInternationalLicenseID=-1;
        public frmInternationalDriverLicenseApplication()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmInternationalDriverLicenseApplication_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToString("dd-mm-yyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd-mm-yyy");
            lblFees.Text = clsApplicationType.FindApplicationType(6).ApplicationTypeFeese.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd-MM-yyy");
            lblCreatedBy.Text = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
            lklLicensesInfo.Enabled = false;
            lklLicensesHistory.Enabled = false;
        }

        

      private void btnIssue_Click(object sender, EventArgs e)
        {
            clsInternationalLicense
                I_License = new clsInternationalLicense();

           I_License.ApplicantPersonID = ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID;
           I_License.ApplicationDate = DateTime.Now;
           I_License.ApplicationTypeID = (short)clsApplication.enApplicationType.NewInternational;
           I_License.ApplicationStatus = (short)clsApplication.enStatus.Complete;
           I_License.LastStatusDate = DateTime.Now;
           I_License.PaidFees = clsApplicationType.FindApplicationType((short)clsApplication.enApplicationType.NewInternational).ApplicationTypeFeese; 
           I_License.CreatedByUserID = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserID;
           I_License.DriverID = ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverID;
           I_License.IssuedUsingLocalLicenseID = _SelectedLicenseID;
           I_License.IssueDate = DateTime.Now;
           I_License.ExpirationDate = DateTime.Now.AddYears(1) ;
           I_License.IsActive = true;

            int ActiveInternationalLicenseID = I_License.GetActiveInternationalLicenseID(_SelectedLicenseID);


            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show("This License is already exists , choose another one!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _CurrentInternationalLicenseID = ActiveInternationalLicenseID;
                lklLicensesInfo.Enabled = true;
                btnIssue.Enabled = false;
                return;
            }
            if (ctrDriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassID != 3)
            {
                MessageBox.Show("The international license should issue for license class only!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
                bool isIssued = I_License.Save();
                MessageHelper.ShowMessageResult(isIssued, "International License Issued", "The Issue Was Failed ");
                if (!isIssued)
                    return; 
                 
                
            lblInterLicenseID.Text = I_License.InternationalLicenseID.ToString();
            lblInterAppID.Text = I_License.ApplicationID.ToString();
            btnIssue.Enabled = false;
            lklLicensesInfo.Enabled = true;
            _CurrentInternationalLicenseID = I_License.InternationalLicenseID;
        }
        
        

        private void lklLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                frmLicenseHistory licenseHistory = new frmLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
                licenseHistory.Show();
           
        }

        private void lklInternationalLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo internationalLicense
                = new frmInternationalLicenseInfo(_CurrentInternationalLicenseID);
            internationalLicense.Show();

        }

        private void ctrDriverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            _SelectedLicenseID = obj;
            lklLicensesHistory.Enabled = (_SelectedLicenseID != -1);
            if (_SelectedLicenseID == -1)
            {
                return;
            }
            lblLocalLicenseID.Text = _SelectedLicenseID.ToString();
            lklLicensesHistory.Enabled = true;
        }

        private void lblLocalLicenseID_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

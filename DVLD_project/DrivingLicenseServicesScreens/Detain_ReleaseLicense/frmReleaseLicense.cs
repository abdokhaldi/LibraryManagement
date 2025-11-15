using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Detain_Release;
using DVLD_BussinessLayer.LicensClass;
using DVLD_BussinessLayer.Users;
using DVLD_DataAccess.ApplicationTypes;
using DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens.Detain_ReleaseLicense
{
    public partial class frmReleaseLicense : Form
    {
        private int _SelectedLicenseID=-1;
        public frmReleaseLicense()
        {
            InitializeComponent();
        }
        public frmReleaseLicense(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;
            ctrDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
        }

      private void lklLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(Convert.ToInt32(lblLicenseID.Text));
            licenseInfo.Show();
        }

        private void lklLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
                frmLicenseHistory licenseHistory =
                    new frmLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
                licenseHistory.Show();
            }
            
        

        // obj parameter : is a LicenseID Backed when the license is found 
        private void ctrDriverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            _SelectedLicenseID = obj;
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            lklLicensesHistory.Enabled = (_SelectedLicenseID != -1);
            
            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("This License Is Not Detained, try another one!","Not Allowed", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                btnRelease.Enabled = false;
                return;
            }
            btnRelease.Enabled = true;
            lblDetainID.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicense.detainedLicenseInfo.DetainID.ToString(); ;
            lblFineFees.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicense.detainedLicenseInfo.FinFees.ToString();
            lblDetainDate.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicense.detainedLicenseInfo.DetainDate.ToString("dd-mm-yyy");
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(5).ApplicationTypeFeese.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblFineFees.Text) + Convert.ToSingle(lblApplicationFees.Text)).ToString();            
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(!MessageHelper.SowMessageConform("Are you sure you want to release this license"))
            {
                MessageBox.Show("the release was canceled!");
                return;
            }

            int ApplicationID = -1;
        //    bool isReleased = ctrDriverLicenseInfoWithFilter1.SelectedLicense.Release(clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserID,ref ApplicationID);
            //MessageHelper.ShowMessageResult(isReleased,"The detained license released successfully.","Failed to release this detained license!");
            
            lblApplicationID.Text = ApplicationID.ToString();
            btnRelease.Enabled = false;
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
            lklLicensesInfo.Enabled = true;
           // lblCreatedBy.Text = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
        }
    }
}

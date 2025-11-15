using DVLD_BussinessLayer.Detain_Release;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.Users;
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
    public partial class frmDetainLicense : Form
    {
        int _SelectedLicenseID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
        }


       
        private void lklLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             frmLicenseHistory licenseHistory = new frmLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
                licenseHistory.Show();
          }
            
        

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lklLicensesInfo.Enabled = false;
            lklLicensesHistory.Enabled = false;
            lblDetainDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblCreatedBy.Text = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            int DetainID = ctrDriverLicenseInfoWithFilter1.SelectedLicense.Detain(clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserID, Convert.ToSingle(txtFineFees.Text));
            if (!MessageHelper.SowMessageConform("Are you sure yo want to detain this license"))
            {
                return;
            }
            bool isDetained = (DetainID != -1);


            MessageHelper.ShowMessageResult(isDetained, "The License is Detained Successfully", "Detain the license was failed");
            if (isDetained)
            {
                lblDetainID.Text = DetainID.ToString();
                btnDetain.Enabled = false;
                lklLicensesInfo.Enabled = true;
            }
        }

        private void lklLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(Convert.ToInt32(lblLicenseID.Text));
            licenseInfo.Show();
        }

        private void ctrDriverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            _SelectedLicenseID = obj;
            lblLicenseID.Text = _SelectedLicenseID.ToString();
            lklLicensesHistory.Enabled = true;
            if (ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("This License Is Already Detained!");
                btnDetain.Enabled = false;
                return;
            }
            
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
            btnDetain.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

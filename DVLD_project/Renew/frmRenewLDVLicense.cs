using DVLD_BussinessLayer;
using DVLD_BussinessLayer.LicensClass;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.Users;
using DVLD_DataAccess.ApplicationTypes;
using DVLD_project.DrivingLicenseServicesScreens;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_project.Renew
{
    public partial class frmRenewLDVLicense : Form
    {

        private int _newLicenseID = -1;
        
        public frmRenewLDVLicense()
        {
            InitializeComponent();
        }

        

        
        
        private void lklLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
              frmLicenseHistory licenseHistory =
                 new frmLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID);
                licenseHistory.Show();
            
        }

        private void frmRenewLDVLicense_Load(object sender, EventArgs e)
        {
            lblIssueDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblAppDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblApplicationFees.Text = clsApplicationType.FindApplicationType(2).ApplicationTypeFeese + "$";
            lklLicensesInfo.Enabled = false;
            lklLicensesHistory.Enabled = false;
        }

        private void lklLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(Convert.ToInt32(lblRenewdLicenseID.Text));
            licenseInfo.Show();
        }

        Decimal fees(string fees)
        {
           // to convert string number from number with $ to pure number without $ symbol
           Decimal Fees =  Convert.ToDecimal(fees.Trim().Split('$')[0]);
            return Fees;
        }
        private void ctrDriverLicenseInfoWithFilter1_OnSelectedLicense(int obj)
        {
            int SelectedLicenseID = obj;
            
            if (SelectedLicenseID == -1)
            {
               MessageBox.Show("No License Exist");
                return;
            }
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lblLicenseFees.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.ClassFees + "$";
         //   lblCreatedBy.Text = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
            lblTotalFees.Text = (fees(lblApplicationFees.Text) + fees(lblLicenseFees.Text)) + "$";
            lblExpirationDate.Text = DateTime.Now.AddYears(ctrDriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.DefaultValidityLength).ToString("dd-mm-yyyy"); 
            lklLicensesHistory.Enabled = true;
            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show($"The License with LicenseID : {SelectedLicenseID} is not expired yet: it will be expired in : {ctrDriverLicenseInfoWithFilter1.SelectedLicense.ExpirationDate}", "Not Expired",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                btnRenew.Enabled = false;
                ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
                return;
            }
            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show($"The License : {SelectedLicenseID} Is Not Active, Choose another active license","Not Active", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnRenew.Enabled = false;
                return;
            }

            // if the user tried with Active License
            btnRenew.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            
           if(MessageHelper.SowMessageConform("Are you sure you want to renew this license?")){

 //               clsLicense newLicense = ctrDriverLicenseInfoWithFilter1.SelectedLicense.RenewLicense(txtNote.Text,clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserID);
               // bool isRenewed = (newLicense !=null);
               // MessageHelper.ShowMessageResult(isRenewed,"The license renewed Successfully","Failed to renew this license");
                /*if (isRenewed)
                {
                    _newLicenseID = newLicense.LicenseID;
                    lblRenewdLicenseID.Text = newLicense.LicenseID.ToString();
                    lblRenewLApplication.Text = newLicense.ApplicationID.ToString();
                    
                }*/
            }
        }
    }
}

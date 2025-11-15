using DVLD_BussinessLayer;
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
        public frmInternationalDriverLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmInternationalDriverLicenseApplication_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblFees.Text = clsApplicationType.FindApplicationType(6).ApplicationTypeFeese.ToString();
            lblExpirationDate.Text = (Convert.ToDateTime(lblIssueDate.Text).AddYears(1)).ToString();
           // lblCreatedBy.Text = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
            lklLicensesInfo.Enabled = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(txtSearch.Text);
            ctrDriverLicenseInfo1.LoadLicenseInfo(LicenseID);
          // lblLocalLicenseID.Text = ctrDriverLicenseInfo1.lblLocalLicenseID;
           
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
           

         //  I_License.ApplicantPersonID = clsPerson.FindPerson("NationalNo",ctrDriverLicenseInfo1.lbl_NationalNo).PersonID;
           

           
          //  bool isThirdClass = ctrDriverLicenseInfo1.lbl_ClassName.Contains("Class 3");
            /*if (!Exist && Active && isThirdClass)
            {
                bool succeed = I_License.IssueApplication_InternationalLicense();
                MessageHelper.ShowMessageResult(succeed, "International License Issued", "The Issue Was Failed ");
                if (succeed)
                {
                    lblInterLicenseID.Text = I_License.InternationalLicenseID.ToString();
                    lblInterAppID.Text = I_License.ApplicationID.ToString();
                    btnSearch.Enabled = false;
                    btnIssue.Enabled = false;
                    lklLicensesInfo.Enabled = true;
                }
            }else
            {
                MessageBox.Show("the International license is already existing or license is not active for this local license","",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                btnSearch.Enabled = false;
                btnIssue.Enabled = false;
            }*/
        
        }

        private void lklLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool isConverted = int.TryParse(lblLocalLicenseID.Text, out int _isConverted);
            if (isConverted)
            {
              //  frmLicenseHistory licenseHistory = new frmLicenseHistory(ctrDriverLicenseInfo1.lbl_NationalNo);
              //  licenseHistory.Show();
            }else
            {
                MessageBox.Show($"There is no international license Issued for this license yet");
            }
        }

        private void lklLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*frmInternationalLicenseInfo inter_licenseInfo
                = new frmInternationalLicenseInfo(Convert.ToInt32(lblInterLicenseID.Text));
            inter_licenseInfo.Show();
*/
        }
    
    
    }
}

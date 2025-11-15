using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.UsifiedModels;
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
    public partial class ctrInternationalLicenseInfo : UserControl
    {
        public ctrInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadProfileImage(string imagePath, int gender)
        {
            if (imagePath != string.Empty)
            {
                pbProfileImage.ImageLocation = imagePath;
                return;
            }
             MessageBox.Show($"The license doesn't have any imagePath = {imagePath}", "No Profile Image",MessageBoxButtons.OK,MessageBoxIcon.Error);
            if (gender == 0)
            {
                pbProfileImage.Image = Properties.Resources.user_male;
            }else
            {
                pbProfileImage.Image = Properties.Resources.user_female;
            }
        }
        void FillControlValues(clsInternationalLicense internationalLicenseInfo)
        {

            lblName.Text = internationalLicenseInfo.ApplicantPersonFullName;
            lblInterLicenseID.Text = internationalLicenseInfo.InternationalLicenseID.ToString();
            lblLicenseID.Text = internationalLicenseInfo.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = internationalLicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = internationalLicenseInfo.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = internationalLicenseInfo.IssueDate.ToString("dd-MM-yyy");
            lblIsActive.Text = (internationalLicenseInfo.IsActive == true) ? "Yes" : "No";
            lblApplicationID.Text = internationalLicenseInfo.ApplicationID.ToString();
            lblDateOfBirth.Text = internationalLicenseInfo.DriverInfo.PersonInfo.DateOfBirth.Value.ToString("dd-MM-yyy");
            lblDriverID.Text = internationalLicenseInfo.DriverID.ToString();
            lblExoirationDate.Text = internationalLicenseInfo.ExpirationDate.ToString("dd-MM-yyy");
            _LoadProfileImage(internationalLicenseInfo.DriverInfo.PersonInfo.ImagePath, internationalLicenseInfo.DriverInfo.PersonInfo.Gender);
        }

        public void LoadInternationalLicenseInfo(int internationalLicenseID)
        {
            clsInternationalLicense internationalLicense =
                clsInternationalLicense.FindInternationalLicenseInfoByID(internationalLicenseID);
            if (internationalLicense == null)
            {
                MessageBox.Show($"The international license with ID:{internationalLicenseID} was not found!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillControlValues(internationalLicense);
        }

        
    }
}

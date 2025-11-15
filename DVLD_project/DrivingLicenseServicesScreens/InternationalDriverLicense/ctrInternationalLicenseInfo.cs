using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
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

        void FillControlValues()
        {

           // lblName.Text = intr_license.FullName;
           // lblInterLicenseID.Text = intr_license.Inter_LicenseID.ToString();
           // lblLicenseID.Text = intr_license.LicenseID.ToString();
           // lblNationalNo.Text = intr_license.NationalNo;
           // lblGendor.Text = intr_license.Gender == 0 ? "Male" : "Female";
           // lblIssueDate.Text = intr_license.IssueDate.Value.ToString("dd-MM-yyy");
           // lblIsActive.Text = (intr_license.IsActive == true) ? "Yes" : "No";
           // lblDateOfBirth.Text = intr_license.DateOfBirth.Value.ToString("dd-MM-yyy");
           // lblDriverID.Text = intr_license.DriverID.ToString();
           // lblExoirationDate.Text = intr_license.ExpirationDate.Value.ToString("dd-MM-yyy");
           // lblApplicationID.Text = intr_license.ApplicationID.ToString();
           // pbProfileImage.ImageLocation = intr_license.ImagePath;
        }

/*        public void FillInternationalLicenseInfo(int intr_licenseID)
        {
            clsInternationalLicense intr_license =
                clsInternationalLicense.FindInternationalLicenseInfoByID(intr_licenseID);

              FillControlValues(intr_license);
        }
*/
        private void ctrInternationalInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

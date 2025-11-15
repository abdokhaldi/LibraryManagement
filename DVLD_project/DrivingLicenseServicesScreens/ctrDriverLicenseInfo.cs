using DVLD_BussinessLayer.Detain_Release;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications
{
    public partial class ctrDriverLicenseInfo : UserControl
    {
        private int _LicenseID;
        public int LicenseID
        {
            get { return _LicenseID; }
        }
        private clsLicense _SelectedLicense;
        public clsLicense SelectedLicense
        {
            get { return _SelectedLicense; }
        }
         public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }
        void FillControlValues( clsLicense license)
        {
            lblClassName.Text = license.LicenseClassInfo.LicenseClassName;
            lblName.Text = license.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = license.LicenseID.ToString();
            lblNationalNo.Text = license.DriverInfo.PersonInfo.NationalNo;
        //    lblGendor.Text = license.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIssueDate.Text = license.IssueDate.ToString("dd-MM-yyy");
            lblIssueReason.Text = (license.IssueReason == 1) ? "First Time" : (license.IssueReason == 2)?"Renew" : (license.IssueReason == 3)?"Lost" : (license.IssueReason == 4)?"Damaged": (license.IssueReason == 5)?"Detained":"Other";
            lblNotes.Text = license.Notes;
            lblIsActive.Text = (license.IsActive == true) ? "Yes" : "No";
            lblDateOfBirth.Text = license.DriverInfo.PersonInfo.DateOfBirth.Value.ToString("dd-MM-yyy");
            lblDriverID.Text = license.DriverID.ToString();
            lblExpirationDate.Text = license.ExpirationDate.ToString("dd-MM-yyy");
            lblIsDetained.Text = clsDetainedReleaseLicense.IsDetainedLicense(Convert.ToInt32(lblLicenseID.Text))?"Yes":"No";
            pbProfileImage.ImageLocation = license.DriverInfo.PersonInfo.ImagePath;
        }
       

       public void LoadLicenseInfo(int LicenseID)
        {
            clsLicense licenseInfo = clsLicense.FindLicenseInfoByID(LicenseID);
            if (licenseInfo != null)
            {
                FillControlValues( licenseInfo);
                _LicenseID = licenseInfo.LicenseID;
                _SelectedLicense = licenseInfo;
                return;
            }
            
                _LicenseID = -1;
           }

        
    }   
      
}

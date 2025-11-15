using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.UsifiedModels;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens
{
    public partial class frmLicenseHistory : Form
    {
        private int _selectedPersonID;
        private enum enLicenseType { Local = 1, International = 2 }

        public frmLicenseHistory(int personID)
        {
            InitializeComponent();
            
            _selectedPersonID = personID;
           
        }
        private DataTable _LoadLicensesData(enLicenseType licenseType)
        {
            DataTable licenses;
            
            switch (licenseType)
            {
               case enLicenseType.Local:
                    licenses = clsLicense.GetLicensesHistoryByDriverID(_selectedPersonID);
                    return licenses;
                case enLicenseType.International:
                    licenses =  clsInternationalLicense.GetInternationalLicensesHistoryByPersonID(_selectedPersonID);
                    return licenses;
               }
            return null;
        }
        

        

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            tbLocalLicenses.Select();
            ctrAddPersonWithFilter1._LoadPersonData(_selectedPersonID);
           
            ctrAddPersonWithFilter1.gbFilterEnabled = false;

          }

  private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         private void ctrAddPersonWithFilter1_OnSelectedPerson(int obj)
        {
            _selectedPersonID = obj;
            if (_selectedPersonID != -1)
            {
              _dtLocalLicenses.DataSource =_LoadLicensesData(enLicenseType.Local);
                _dtInternationalLicenses.DataSource = _LoadLicensesData(enLicenseType.International);
            }
        }
    }
}

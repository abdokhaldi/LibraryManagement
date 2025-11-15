using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_project.People.Components;

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens
{
    public partial class frmLicenseHistory : Form
    {
        private int _personID;
      //  private DataGridView _dataGridViewLicenses;
        
        public frmLicenseHistory(int personID)
        {
            InitializeComponent();
            
            _personID = personID;
           
        }
        
        private DataTable _LoadLicensesData(string licenseType)
        {
            DataTable licenses;
            
            switch (licenseType)
            {
               case "local":
                    licenses = clsLicense.GetLicensesHistoryByDriverID(_personID);
                    return licenses;
                case "international":
                    licenses = null;// clsInternationalLicense.GetInternationalLicensesHistoryByPersonID(personID);
                    return licenses;
               }
            return null;
        }
        

        private void FillPersonalInfo(int personID)
        {
            
        }
        

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            tbLocalLicenses.Select();
            


        }

  private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrAddPersonAsUser1_Load(object sender, EventArgs e)
        {

        }
    }
}

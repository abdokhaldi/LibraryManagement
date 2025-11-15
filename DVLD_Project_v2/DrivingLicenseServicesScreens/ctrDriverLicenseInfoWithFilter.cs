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

namespace DVLD_project.DrivingLicenseServicesScreens
{
    public partial class ctrDriverLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnSelectedLicense;
        protected virtual void LicenseSelected(int LicenseID)
        {
             Action<int> handler = OnSelectedLicense;
            if (handler != null)
            {
                handler(LicenseID);
            }
        }

        private int _LicenseID =-1;
        public int LicenseID
        {
            get { return ctrDriverLicenseInfo1.LicenseID; }
        }
        public bool FilterEnabled
        {
           set
            {
                gbFilter.Enabled = value;
            }
        }


        public clsLicense SelectedLicense
        {
            get { return ctrDriverLicenseInfo1.SelectedLicense; }
        }

        public ctrDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            
            ctrDriverLicenseInfo1.LoadLicenseInfo(LicenseID);
            if (ctrDriverLicenseInfo1.LicenseID==-1)
            {
                MessageBox.Show($"No License Exists By ID:{LicenseID}");
                return;
            }
            txtSearch.Text = LicenseID.ToString();
            if (OnSelectedLicense != null)
            {
                OnSelectedLicense(LicenseID);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
               return;
            }
            _LicenseID = Convert.ToInt32(txtSearch.Text.Trim());
            LoadLicenseInfo(_LicenseID);
            
        }

        private void ctrDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void BtnSearch_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

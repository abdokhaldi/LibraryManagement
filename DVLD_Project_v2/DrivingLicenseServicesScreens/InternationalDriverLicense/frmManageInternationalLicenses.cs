using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Driver;
using DVLD_BussinessLayer.UsifiedModels;
using DVLD_project.DrivingLicenseServicesScreens;
using DVLD_project.DrivingLicenseServicesScreens.InternationalDriverLicense;
using DVLD_project.People.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_v2.DrivingLicenseServicesScreens.InternationalDriverLicense
{
    public partial class frmManageInternationalLicenses : Form
    {
        DataTable _dt;
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _dt = new DataTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
             _dt = clsInternationalLicense.GetInternationalLicenseList();
            dgvInternationalLicenses.DataSource = _dt;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            DataView dtv = _dt.DefaultView;
            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    if (int.TryParse(txtFilterValue.Text, out int interID))
                    {
                        dtv.RowFilter = $"InternationalLicenseID ={interID}";
                    }
                    else
                    {
                        dtv.RowFilter = "";
                    }
                    dgvInternationalLicenses.DataSource = dtv;
                    break;
                case "Application ID":
                    if (int.TryParse(txtFilterValue.Text, out int appID))
                    {
                        dtv.RowFilter = $"ApplicationID ={appID}";
                    }
                    else
                    {
                        dtv.RowFilter = "";
                    }
                    dgvInternationalLicenses.DataSource = dtv;
                    break;
                case "Driver ID":
                    if (int.TryParse(txtFilterValue.Text, out int driverID))
                    {
                        dtv.RowFilter = $"DriverID ={driverID}";
                    }
                    else
                    {
                        dtv.RowFilter = "";
                    }
                    dgvInternationalLicenses.DataSource = dtv;
                    break;

                case "Local License ID":
                    if (int.TryParse(txtFilterValue.Text, out int localLicenseID))
                    {
                        dtv.RowFilter = $"IssuedUsingLocalLicenseID ={localLicenseID}";
                            
                    }
                    else
                    {
                        dtv.RowFilter = "";
                    }
                    dgvInternationalLicenses.DataSource = dtv;
                    break;
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = _dt.DefaultView;

            if (cbIsReleased.Text == "All")
            {
                dv.RowFilter = "";
                dgvInternationalLicenses.DataSource = dv;
                return;
            }
            if (cbIsReleased.Text == "Yes")
            {
                dv.RowFilter = $"IsActive={true}";
                dgvInternationalLicenses.DataSource = dv;
                return;
            }

            if (cbIsReleased.Text == "No")
            {
                dv.RowFilter = $"IsActive={false}";
                dgvInternationalLicenses.DataSource = dv;
                return;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = false;
            }
            else
            {
                if (cbFilterBy.SelectedIndex == 5)
                {
                    txtFilterValue.Visible = false;
                    cbIsReleased.Visible = true;
                }else
                {
                    txtFilterValue.Visible = true;
                    cbIsReleased.Visible = false;
                }
            }
        }

        private void toolStripMenuPersonDetails_Click(object sender, EventArgs e)
        {
           int driverID = (int)dgvInternationalLicenses.SelectedRows[0].Cells[2].Value;
            int personID = clsDriver.FindDriverByID(driverID).PersonID;
            frmPersonDetails personDetails = new frmPersonDetails(personID);
            personDetails.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int driverID = (int)dgvInternationalLicenses.SelectedRows[0].Cells[2].Value;
            int personID = clsDriver.FindDriverByID(driverID).PersonID;
            frmLicenseHistory licenseHistory = new frmLicenseHistory(personID);
            licenseHistory.ShowDialog();
        }

        private void toolStripMenuInternationalDetails_Click(object sender, EventArgs e)
        {
            int internationalLicenseID = (int)dgvInternationalLicenses.SelectedRows[0].Cells[0].Value;
            frmInternationalLicenseInfo internationalLicenseInfo = new frmInternationalLicenseInfo(internationalLicenseID);
            internationalLicenseInfo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmInternationalDriverLicenseApplication newInternationalApplication = new frmInternationalDriverLicenseApplication();
            newInternationalApplication.ShowDialog();
        }
    }
}

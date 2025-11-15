
using DVLD_BussinessLayer.Detain_Release;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications;
using DVLD_project.People.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens.Detain_ReleaseLicense
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void _ResizeDataGridColumns(int[] size)
        {
            for (int i=0;i<dataGridDetainedLicenses.Columns.Count;i++) {
                dataGridDetainedLicenses.Columns[i].Width = size[i];
            }
         }
        void RefreshDetainedLicensesList()
        {
            dataGridDetainedLicenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTable dt = clsDetainedReleaseLicense.GetDetainedLicenseList();
            DataView dv = dt.DefaultView;
            dataGridDetainedLicenses.DataSource = dv;
        }
        
        private void Filter(string filteredBy, DataView dv)
        {
            string filterText = txtSearch.Text;
           
           switch (filteredBy)
            {
                  case "DetainID":
                    
                    if (int.TryParse(filterText, out int detainID))
                    {
                        dv.RowFilter = $"DetainID = {detainID}";
                    }
                    else
                    {
                        dv.RowFilter = ""; // Clear filter if input is invalid
                    }
                    break;
                case "ReleaseApplicationID":
                    if (int.TryParse(filterText, out int applicationID))
                    {
                        dv.RowFilter = $"ReleaseApplicationID = {applicationID}";
                    }
                    else
                    {
                        dv.RowFilter = ""; // Clear filter if input is invalid
                    }
                    break;
                case "IsReleased":
                    if (short.TryParse(filterText, out short isReleased))
                    {
                        dv.RowFilter = $"IsReleased = {isReleased}";
                    }
                    else
                    {
                        dv.RowFilter = ""; // Clear filter if input is invalid
                    }
                    break;

                case "FullName":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}%'";
                    break;
                case "NationalNo":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}%'";
                    break;

                
            }
           dataGridDetainedLicenses.DataSource = dv;
        }

        private void ShowFilterRows()
        {
            DataTable dt = clsDetainedReleaseLicense.GetDetainedLicenseList();
            DataView dv = dt.DefaultView;

            Filter(cbFilterBy.Text, dv);
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            RefreshDetainedLicensesList();
           _ResizeDataGridColumns(new[] { 50, 60, 90, 65, 60, 90, 65, 135, 110 });
            lblRecords.Text = dataGridDetainedLicenses.Rows.Count.ToString(); 
            txtSearch.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowFilterRows();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtSearch.Visible = false;
                RefreshDetainedLicensesList();
            }
            else
            {
                txtSearch.Visible = true;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            /*frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.Show();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReleaseLicense releaseLicense = new frmReleaseLicense();
            releaseLicense.Show();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = (int)dataGridDetainedLicenses.SelectedRows[0].Cells[1].Value;
            frmReleaseLicense releaseLicense = new frmReleaseLicense();
            releaseLicense.Show();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nationalNo = dataGridDetainedLicenses.SelectedRows[0].Cells[6].Value.ToString();
            frmPersonDetails personDetails = new frmPersonDetails(nationalNo);
            personDetails.Show();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = Convert.ToInt32(dataGridDetainedLicenses.SelectedRows[0].Cells[1].Value);
          //  frmDriverLicenseInfo licenseInfo = new frmDriverLicenseInfo(null,licenseID);
          //  licenseInfo.Show();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = (int)dataGridDetainedLicenses.SelectedRows[0].Cells[1].Value;
            int personID = clsLicense.FindLicenseInfoByID(licenseID).DriverInfo.PersonID;
            frmLicenseHistory licenseHistory = new frmLicenseHistory(personID);
            licenseHistory.Show();
        }
    }
}

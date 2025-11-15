
using DVLD_BussinessLayer.Driver;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_project.Drivers
{
    public partial class frmManageDrivers : Form
    {
        DataTable _dt;
        public frmManageDrivers()
        {
            InitializeComponent();
            
        }
        private void Filter(string filteredBy, DataView dv)
        {
            string filterText = txtSearchApplication.Text;

            switch (filteredBy)
            {
                case "DriverID":
                    if (int.TryParse(filterText, out int applicationID))
                    {
                        dv.RowFilter = $"DriverID = {applicationID}";
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

                case "PersonID":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}'";
                    break;
            }
            dataGridDrivers.DataSource = dv;
        }
        private void ShowFilterRows()
        {
           
            DataView dv = _dt.DefaultView;

            Filter(cbFilterBy.Text, dv);
        }

        private void txtSearchApplication_TextChanged(object sender, EventArgs e)
        {
            ShowFilterRows();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _dt = clsDriver.GetDriversList();
            dataGridDrivers.DataSource = _dt;
            dataGridDrivers.Columns[3].Width = 200;
            dataGridDrivers.Columns[5].Width = 130;
            lblRecords.Text = _dt.Rows.Count.ToString();
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

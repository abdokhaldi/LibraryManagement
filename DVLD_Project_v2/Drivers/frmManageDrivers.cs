
using DVLD_BussinessLayer.Driver;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_project.Drivers
{
    public partial class frmManageDrivers : Form
    {
        DataTable _dt;
        public frmManageDrivers()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void Filter(string filteredBy, DataView dv)
        {
            string filterText = txtFilter.Text;

            switch (filteredBy)
            {
                case "DriverID":
                    if (int.TryParse(filterText, out int driverID))
                    {
                        dv.RowFilter = $"DriverID = {driverID}";
                    }
                    else
                    {
                        dv.RowFilter = ""; // Clear filter if input is invalid
                    }
                    break;

                case "PersonID":
                    if (int.TryParse(txtFilter.Text, out int personID))
                        dv.RowFilter = $"{filteredBy} = '{personID}'";
                    else
                        dv.RowFilter = "";
                    break;

                case "FullName":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}%'";
                    break;
                case "NationalNo":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}%'";
                    break;

                
            }
            dataGridDrivers.DataSource = dv;
            for (int i = 0; i < dataGridDrivers.RowCount; i++)
            {
                dataGridDrivers.Rows[i].Height = 40;
            }
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

            cbFilterBy.SelectedIndex = 0;
            txtFilter.Visible = false;

            _dt = clsDriver.GetDriversList();
            dataGridDrivers.DataSource = _dt;
            dataGridDrivers.Columns[1].Width = 108;
            dataGridDrivers.Columns[2].Width = 130;
            dataGridDrivers.Columns[3].Width = 350;
            dataGridDrivers.Columns[4].Width = 150;
            dataGridDrivers.Columns[5].Width = 180;
            lblRecords.Text = _dt.Rows.Count.ToString();
            for (int i = 0; i < dataGridDrivers.RowCount; i++)
            {
                dataGridDrivers.Rows[i].Height = 40;
            }
     }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
           if( cbFilterBy.SelectedIndex == 0)
            {
                txtFilter.Visible = false;
                return;
            }
            txtFilter.Visible = true;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex==2)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (cbFilterBy.SelectedIndex == 3)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (cbFilterBy.SelectedIndex == 4)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblRecords_Click(object sender, EventArgs e)
        {

        }
    }
}

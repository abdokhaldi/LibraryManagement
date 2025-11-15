using DVLD_DataAccess.ApplicationTypes;
using DVLD_DataAccess.TestTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.TestTypeScreens
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }
        private void _DataGridTestTypesConfig()
        {
            //dataGridApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridTestTypes.Columns[0].Width = 100;
            dataGridTestTypes.Columns[1].Width = 200;
            dataGridTestTypes.Columns[2].Width = 400;
            dataGridTestTypes.Columns[3].Width = 130;
            dataGridTestTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void _RefereshtTestTypesList()
        {

            DataTable dt = clsTestType.TestTypesList();
            DataView dv = dt.DefaultView;
            dataGridTestTypes.DataSource = dv;
            _DataGridTestTypesConfig();
        }

      private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedItem = dataGridTestTypes.SelectedRows[0].Cells[0].Value;
            int id = Convert.ToInt32(selectedItem);
            frmEditTestTypes editTestType = new frmEditTestTypes(this, id);
            editTestType.Show();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load_1(object sender, EventArgs e)
        {
            _RefereshtTestTypesList();
            lblRecords.Text = dataGridTestTypes.Rows.Count.ToString();
        }
    }
}

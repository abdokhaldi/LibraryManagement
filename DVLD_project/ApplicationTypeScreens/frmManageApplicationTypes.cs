using DVLD_DataAccess.ApplicationTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.ApplicationTypeScreens
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

    private void _DataGridApplicationTypesConfig()
        {        
        //    dataGridApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridApplicationTypes.Columns[0].Width = 150;
            dataGridApplicationTypes.Columns[1].Width = 370;
            dataGridApplicationTypes.Columns[2].Width = 150;
            dataGridApplicationTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    public void _RefereshApplicationTypesList()
        {

            DataTable dt = clsApplicationType.ApplicationTypesList();
            DataView dv = dt.DefaultView;
            dataGridApplicationTypes.DataSource = dv;
            _DataGridApplicationTypesConfig();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
           
            _RefereshApplicationTypesList();
            lblRecords.Text = dataGridApplicationTypes.Rows.Count.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedItem = dataGridApplicationTypes.SelectedRows[0].Cells[0].Value;
            int id = Convert.ToInt32(selectedItem);
            frmEditAppType editApplicationType = new frmEditAppType(this,id);
            editApplicationType.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using BLL_LibraryManagement;
using System;
using System.Windows.Forms;

namespace PL_LibraryManagement.Borrowings
{
    
    public partial class ctrLookUpControl : UserControl
    {
        private string SelectedBorrowerID = "";
        string currentSearchTerm = "";

        private readonly Timer searchTimer = new Timer
        {
            Interval = 400,
            Enabled = false,
        };
        
        public ctrLookUpControl()
        {
            InitializeComponent();
            dgvLookUp.Visible = false;
            
            searchTimer.Tick += timerSearch_tick;
        }

        private void txtLookUp_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
            currentSearchTerm = txtLookUp.Text;
            if (currentSearchTerm.Length < 2)
            {
                dgvLookUp.Visible = false;
                
                searchTimer.Stop(); 
                return;
            }
            else
            {
                dgvLookUp.Visible = true;
                
            }
        }

        private void timerSearch_tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            var people = SmallPersonService.GetPersonAutoSearch(currentSearchTerm);
            
            dgvLookUp.DataSource = people;
        }

        private void dgvLookUp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string personID = dgvLookUp.Rows[e.RowIndex].Cells["PersonID"].Value.ToString();
                string personName = dgvLookUp.Rows[e.RowIndex].Cells["FullName"].Value.ToString();

                txtLookUp.Text = personName;
                SelectedBorrowerID = personID;

                dgvLookUp.Visible = false;
                
            }
        }
    }
}

using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.Borrowings
{
    public partial class ctrBookLookUP : UserControl
    {
        private int SelectedBookID = 0;
        string currentSearchTerm = "";
        public event Action<int> SelectedBookIDShared;
        private readonly Timer searchTimer = new Timer
        {
            Interval = 400,
            Enabled = false,
        };
        public ctrBookLookUP()
        {
            InitializeComponent();
            dgvLookUp.Visible = false;
            dgvLookUp.RowHeadersVisible = false;
            searchTimer.Tick += timerSearch_tick;
        }
        private void CreateColumns()
        {
            dgvLookUp.AutoGenerateColumns = false;
            if (dgvLookUp.Columns.Count > 0) return;
            var columns = new Dictionary<string, (string, int)>
            {
                ["Title99"] = ("Title",0),
                ["BookID"] = ("ID",40),
            };
            UIConfigurator.CreateColumns(dgvLookUp,columns);
        }
        private void txtLookUp_TextChanged_1(object sender, EventArgs e)
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
            var books = SmallBookService.GetBookAutoSearch(currentSearchTerm);
            CreateColumns();
            dgvLookUp.DataSource = books;
        }

        private void dgvLookUp_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {              
                string title = dgvLookUp.Rows[e.RowIndex].Cells[0].Value.ToString();
                string bookID = dgvLookUp.Rows[e.RowIndex].Cells[1].Value.ToString();

                txtLookUp.Text = title;
                SelectedBookID = Convert.ToInt32(bookID);
                if (SelectedBookID <= 0)
                    return; 
                dgvLookUp.Visible = false;
                SelectedBookIDShared?.Invoke(SelectedBookID);
            }
        }

        private void txtLookUp_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvLookUp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PL_LibraryManagement.Borrowings
{
    
    public partial class ctrLookUpControl : UserControl
    {
        private int _SelectedBorrowerID = 0;
        string _currentSearchTerm = "";
        public event Action<int> SelectedBorrowerIDShared;

        private readonly Timer searchTimer = new Timer
        {
            Interval = 400,
            Enabled = false,
        };
        private void CreateColumns()
        {
            
            if (dgvLookUp.Columns.Count > 0)
                return;
            dgvLookUp.AutoGenerateColumns = false ;
            var columns = new Dictionary<string, (string, int)>
            { 
                
                ["FullName99"] = ("Name",0),
                ["PersonID"] = ("ID",40),
                
            };

            UIConfigurator.CreateColumns(dgvLookUp,columns);
        }
        public ctrLookUpControl()
        {
            InitializeComponent();
            dgvLookUp.Visible = false;
            dgvLookUp.RowHeadersVisible = false;
            searchTimer.Tick += timerSearch_tick;
        }

        private void AdjustResultsRowHeight(bool showResults)
        {
            if (tbLookUp.RowStyles.Count <= 1)
                return;

            
            RowStyle rowStyle = tbLookUp.RowStyles[1];

            if (showResults)
            {
                rowStyle.SizeType = SizeType.Percent;
                rowStyle.Height = 100; 

                dgvLookUp.Visible = true;
            }
            else
            {
                
                dgvLookUp.Visible = false;

                rowStyle.SizeType = SizeType.Absolute;

                rowStyle.Height = 1;
            }

            tbLookUp.PerformLayout();

        }
        private void txtLookUp_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
            _currentSearchTerm = txtLookUp.Text;
            if (_currentSearchTerm.Length < 2)
            {
                
                AdjustResultsRowHeight(false);
                searchTimer.Stop(); 
                return;
            }
            else
            {
                
                AdjustResultsRowHeight(true);
            }
        }

        private void timerSearch_tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            var people = SmallPersonService.GetPersonAutoSearch(_currentSearchTerm);
            
            CreateColumns();
            dgvLookUp.DataSource = people;
        }

        private void dgvLookUp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {                
                string personName = dgvLookUp.Rows[e.RowIndex].Cells[0].Value.ToString();
                string personID = dgvLookUp.Rows[e.RowIndex].Cells[1].Value.ToString();

                txtLookUp.Text = personName;
                _SelectedBorrowerID = Convert.ToInt32(personID);
                if (_SelectedBorrowerID <= 0)
                    return;

                dgvLookUp.Visible = false;
                SelectedBorrowerIDShared?.Invoke(_SelectedBorrowerID);
            }
        }
    }
}

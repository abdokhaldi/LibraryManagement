using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PL_LibraryManagement.People.UserControls
{
    public partial class ctrPeopleList : UserControl
    {
        public event Action<PersonService> PersonSelected;
        public event Action<PersonService> PersonSelectedToEdit;
        public event  Action CardInfoShowed ;
        private List<PersonService> _peopleList ;
         
        public ctrPeopleList()
        {
            InitializeComponent();
            SetupUI();
            dgvPeople.DefaultCellStyle.Font = AppFonts.Button;
            dgvPeople.ColumnHeadersDefaultCellStyle.Font = AppFonts.Button;
            dgvPeople.ColumnHeadersHeight = 35;
            dgvPeople.RowTemplate.Height = 30;
            this.Load += ctrPeople_Load;
            
        }

        private void SetupUI()
        {
            AppColors.SetupDataGridViewUI(dgvPeople);
            panel1.Padding = new Padding(10, 10, 10, 10);
            pnlTop.BackColor = AppColors.Background;
            lblTitle.ForeColor = AppColors.Primary;
            lblTitle.Font = AppFonts.Title;
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            txtSearch.Font = AppFonts.Normal;
            lblSearch.Font = AppFonts.Normal;
            
        }

        private void CreateDataGridColumns(DataGridView dataGridView)
        { 
            dgvPeople.AutoGenerateColumns = false;
            if (dgvPeople.Columns.Count == 0)
            {
                var columns = new Dictionary<string, (string, int)>
                {
                    ["FirstName"] = ("First Name", 130),
                    ["LastName"] = ("Last Name", 130),
                    ["Address50"] = ("Address", 0),
                    ["Phone"] = ("Phone", 130),
                    ["Email50"] = ("Email", 0),
                    ["City"] = ("City", 150),
                    ["IsActive"] = ("Is Active", 90),
                };

               UIConfigurator.CreateColumns(dgvPeople, columns);
            }
         }

        
        private void LoadPeople()
        {
            dgvPeople.DataSource = null;
            

            CreateDataGridColumns(dgvPeople);

            dgvPeople.ContextMenuStrip = contextMenuStrip1;

             _peopleList = PersonService.GetAllPeople();

            dgvPeople.DataSource = _peopleList;
                
            dgvPeople.CellFormatting += FormattingDataGridValue;
        }

        private void FormattingDataGridValue(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (dgvPeople.Columns[e.ColumnIndex].DataPropertyName == "IsActive")
            {
                if (e.Value is bool value)
                {
                    e.Value = value ? "Yes" : "No";

                    e.FormattingApplied = true;
                }
            }
         }


        public void RefreshDataGrid()
        {
            LoadPeople();
        }

        private void ctrPeople_Load(object sender, EventArgs e)
        {
            LoadPeople();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }
        private bool AutoFilterBy(string query ,string value)
        {
            return (value != null && value.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private List<PersonService> _FilterPeopleList(string query)
        {
            return _peopleList.Where(
                p => AutoFilterBy(query, p.FirstName)
            || AutoFilterBy(query, p.LastName)).ToList();
        } 

        private void searchTimer_Tick(object sender, EventArgs e)
        {
           // filter automaticly search in dataGridView 

            searchTimer.Stop();

            string query = txtSearch.Text.Trim();
            var filterList = _FilterPeopleList(query);
           
            dgvPeople.DataSource = filterList;


        }

        
        private bool IsRowSelected()
        {
           return (dgvPeople.SelectedRows.Count > 0);
        }
        

        private void cardInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cardInfoToolStripMenuItem.Enabled)
            {
            CardInfoShowed?.Invoke();
            cardInfoToolStripMenuItem.Enabled = false;
            }
            if (IsRowSelected())
            {
                var person = (PersonService)dgvPeople.SelectedRows[0].DataBoundItem;
                PersonSelected?.Invoke(person);
            }
        }

        public void ActiveCardInfoToolStripMenuItem()
        {
            cardInfoToolStripMenuItem.Enabled = true;
        }

        

        private void dgvPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cardInfoToolStripMenuItem.Enabled)
            {
                CardInfoShowed?.Invoke();

                cardInfoToolStripMenuItem.Enabled = false;
            }
            if (IsRowSelected())
            {
                var person = (PersonService)dgvPeople.SelectedRows[0].DataBoundItem;
                
                PersonSelected?.Invoke(person);
            }

        }

        
    private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsRowSelected())
            {
                var person = (PersonService)dgvPeople.SelectedRows[0].DataBoundItem;
                this.Dock = DockStyle.Top;
                PersonSelectedToEdit?.Invoke(person);
            }
       }


    }
}

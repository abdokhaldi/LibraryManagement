using DVLD_BussinessLayer;
using DVLD_project.People.Components;
using DVLD_project.UserScreens.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_project.People.Forms
{
    public partial class frmManagePeople : Form
    {
       // private ctrAddPerson addPerson;
        public DataGridView dataGrid
        {
            get { return dataGridPeople; }
            set { dataGridPeople = value; }
        }
        public frmManagePeople()
        {
            InitializeComponent();

        }

        
        public void RefereshPeopleList()
        {
            DataTable dt = clsPerson.GetPeopleList();
            dataGridPeople.DataSource = dt;
            lblRecords.Text = dataGridPeople.RowCount.ToString();
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            dataGridPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtSearchPrsn.Visible = false;
            btnSearch.Visible = false;
           // dataGridPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            RefereshPeopleList();
            
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtSearchPrsn.Visible = false;
                btnSearch.Visible = false;
                RefereshPeopleList();
            } else
            {
                txtSearchPrsn.Visible = true;
                btnSearch.Visible = true;
            }

        }
        private void ShowFilteredRows()
        {
            DataTable dt = clsPerson.GetPeopleList();
            DataView dv = dt.DefaultView;

            Filter(cbFilterBy.Text, dv);
        }

        private void Filter(string filteredBy, DataView dv)
        {
            switch (filteredBy)
            {
                case "PersonID":
                    {

                        dv.RowFilter = $"PersonID={txtSearchPrsn.Text}";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
                case "NationalNo":
                    {

                        dv.RowFilter = $"NationalNo='{txtSearchPrsn.Text}'";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
                case "FirstName":
                    {

                        dv.RowFilter = $"FirstName='{txtSearchPrsn.Text}'";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
                case "LastName":
                    {

                        dv.RowFilter = $"LastName='{txtSearchPrsn.Text}'";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
                case "ThirdName":
                    {

                        dv.RowFilter = $"ThirdName='{txtSearchPrsn.Text}'";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
                case "SecondName":
                    {

                        dv.RowFilter = $"FourthName='{txtSearchPrsn.Text}'";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
                case "Gendor":
                    {

                        dv.RowFilter = $"Gendor='{txtSearchPrsn.Text}'";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
                case "Phone":
                    {

                        dv.RowFilter = $"Phone='{txtSearchPrsn.Text}'";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
                case "Email":
                    {

                        dv.RowFilter = $"Email='{txtSearchPrsn.Text}'";
                        dataGridPeople.DataSource = dv;
                        txtSearchPrsn.Text = string.Empty;
                        break;
                    }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowFilteredRows();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selecterRow = dataGridPeople.SelectedRows[0].Cells[0].Value != null ?
                Convert.ToInt32(dataGridPeople.SelectedRows[0].Cells[0].Value) : 0;

            clsPerson person = clsPerson.FindPerson("PersonID",selecterRow);
            frmAddNewPerson addNewPerson = new frmAddNewPerson(this, person);
            addNewPerson.Show();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedRow = dataGridPeople.SelectedRows[0].Cells[0].Value;
            int personID = Convert.ToInt32(selectedRow);

            if (MessageBox.Show("Are you sure to delete this person", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.DeletePersonByID(personID))
                {
                    MessageBox.Show($"the person {personID} is deleted successfuly");
                    RefereshPeopleList();
                }
                else
                {
                    MessageBox.Show($"the person {personID} failed to delete");
                }
            }
            else
            {
                MessageBox.Show($"the deletion was canceld");
            }
        }

        private void showDetaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedRow = dataGridPeople.SelectedRows[0].Cells[0].Value;
            int personID = Convert.ToInt32(selectedRow);
            frmPersonDetails personDetails = new frmPersonDetails(personID);
            personDetails.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewPerson addNewPerson = new frmAddNewPerson(this);
            addNewPerson.Show();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddNewPerson addNewPerson = new frmAddNewPerson(this);
            addNewPerson.Show();
        }

        private void dataGridUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}

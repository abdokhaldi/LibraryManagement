using DVLD_BussinessLayer;
using DVLD_project.People.Components;
using DVLD_project.UserScreens.Forms;
using DVLD_Project_v2.PeopleScreens.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_project.People.Forms
{
    public partial class frmManagePeople : Form
    {
        DataTable _dt;
       // private ctrAddPerson addPerson;
        public DataGridView dataGrid
        {
            get { return dataGridPeople; }
            set { dataGridPeople = value; }
        }
        public frmManagePeople()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        
        public void RefereshPeopleList()
        {
           _dt = clsPerson.GetPeopleList();
            dataGridPeople.DataSource = _dt;
            lblRecords.Text = dataGridPeople.RowCount.ToString();
            
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            dataGridPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtSearchPrsn.Visible = false;
            cbGender.SelectedIndex = 0;
            dataGridPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            RefereshPeopleList();
            
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtSearchPrsn.Visible = false;
                cbGender.Visible = false;
                
                RefereshPeopleList();
                
                return;
            }
            if (cbFilterBy.Text == "Gender")
            {
                txtSearchPrsn.Visible = false;
                cbGender.Visible = true;
            }
            else
            {
                txtSearchPrsn.Visible = true;
                cbGender.Visible = false;
            }

        }
        private void ShowFilteredRows()
        {
             _dt = clsPerson.GetPeopleList();
            DataView dv = _dt.DefaultView;

            Filter(cbFilterBy.Text, dv);
        }

        private void Filter(string filteredBy, DataView dv)
        {
            switch (filteredBy)
            {
                case "PersonID":
                    {
                        if (int.TryParse(txtSearchPrsn.Text, out int personID))
                        {
                            dv.RowFilter = $"PersonID={personID}";
                            
                        }
                        else
                        {
                            dv.RowFilter = "";
                        }
                        dataGridPeople.DataSource = dv;
                        break;
                    }
                case "NationalNo":
                    {

                        dv.RowFilter = $"NationalNo LIKE '%{txtSearchPrsn.Text}%'";
                        dataGridPeople.DataSource = dv;
                       break;
                    }
                case "FirstName":
                    {

                        dv.RowFilter = $"FirstName LIKE '%{txtSearchPrsn.Text}%'";
                        dataGridPeople.DataSource = dv;
                        
                        break;
                    }
                case "LastName":
                    {

                        dv.RowFilter = $"LastName Like '%{txtSearchPrsn.Text}%'";
                        dataGridPeople.DataSource = dv;
                        
                        break;
                    }
                case "ThirdName":
                    {

                        dv.RowFilter = $"ThirdName LIKE '%{txtSearchPrsn.Text}%'";
                        dataGridPeople.DataSource = dv;
                        
                        break;
                    }
                case "SecondName":
                    {

                        dv.RowFilter = $"FourthName Like '%{txtSearchPrsn.Text}%'";
                        dataGridPeople.DataSource = dv;
                        
                        break;
                    }
                
                case "Phone":
                    {

                        dv.RowFilter = $"Phone LIKE '%{txtSearchPrsn.Text}%'";
                        dataGridPeople.DataSource = dv;
                       
                        break;
                    }
                case "Email":
                    {

                        dv.RowFilter = $"Email LIKE '%{txtSearchPrsn.Text}%'";
                        dataGridPeople.DataSource = dv;
                        
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
            int personID = (int)dataGridPeople.SelectedRows[0].Cells[0].Value;


            frmAddUpdatePerson addNewPerson = new frmAddUpdatePerson(this, personID);
            addNewPerson.ShowDialog();
            
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
            frmAddUpdatePerson addNewPerson = new frmAddUpdatePerson(this);
            
            addNewPerson.ShowDialog();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addNewPerson = new frmAddUpdatePerson(this);
            addNewPerson.Show();
        }

       

        private void txtSearchPrsn_TextChanged(object sender, EventArgs e)
        {
            ShowFilteredRows();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGender.SelectedIndex == 0)
            {
                RefereshPeopleList();
                
                return;
            }
            
            DataView dv = _dt.DefaultView;
            dv.RowFilter = $"Gendor = '{cbGender.Text}'";
            dataGridPeople.DataSource = dv;
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

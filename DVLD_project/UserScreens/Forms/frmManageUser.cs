using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Users;
using DVLD_project.UserScreens.Forms;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace DVLD_project.UserScreens
{
    public partial class frmManageUser : Form
    {
        public frmManageUser()
        {
            InitializeComponent();
        }

        public void RefereshUsersList()
        {
            dataGridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTable dt = clsUser.GetUsersList();
            lblRecords.Text = dt.Rows.Count.ToString();

            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridUsers.DataSource = dt;
                for (int i = 0; i < dataGridUsers.Columns.Count; i++)
                {
                    if (i == 2)
                    {
                        dataGridUsers.Columns[i].Width = 250;
                        i += 1;
                    }
                    dataGridUsers.Columns[i].Width = 100;
                }

            }
            else
            {
                MessageBox.Show("No data found.");
            }
        }
        private void frmManageUser_Load(object sender, EventArgs e)
        {
            RefereshUsersList();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser addUser = new frmAddUser();
            addUser.Show();
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowFilteredRows()
        {
              DataTable dt = clsUser.GetUsersList();
                DataView dv = dt.DefaultView;

                Filter(cbFilterBy.Text, dv);
        }
        private void Filter(string filteredBy, DataView dv)
        {
            string filterText = txtSearchUser.Text;

            switch (filteredBy)
            {
                case "UserID":
                    if (int.TryParse(filterText, out int userId))
                    {
                        dv.RowFilter = $"UserID = {userId}";
                    }
                    else
                    {
                        dv.RowFilter = ""; // Clear filter if input is invalid
                    }
                    break;

                case "PersonID":
                    if (int.TryParse(filterText, out int personId))
                    {
                        dv.RowFilter = $"PersonID = {personId}";
                    }
                    else
                    {
                        dv.RowFilter = ""; // Clear filter if input is invalid
                    }
                    break;

                case "Username":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}'";
                    break;

                case "FullName":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}%'";
                    break;

                case "IsActive":
                    ApplyIsActiveFilter(dv);
                    break;
            }

            dataGridUsers.DataSource = dv;
        }
        private void ApplyIsActiveFilter(DataView dv)
        {
            // Assuming comboBoxIsActive has items: "All", "Yes", "No"
            string selectedIsActive = cbIsActive.SelectedItem?.ToString();

            if (selectedIsActive == "Yes")
            {
                dv.RowFilter = "IsActive = true";
            }
            else if (selectedIsActive == "No")
            {
                dv.RowFilter = "IsActive = false";
            }
            else if (selectedIsActive == "All" || string.IsNullOrEmpty(selectedIsActive))
            {
                dv.RowFilter = ""; // Show all records (no filter)
            }
        }
        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text != "IsActive")
            {
                ShowFilteredRows();
            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtSearchUser.Visible = false;
                RefereshUsersList();
            }else if (cbFilterBy.Text == "IsActive")
            {
                cbIsActive.Visible = true;
                txtSearchUser.Visible = false ;
            }
            else
            {
                txtSearchUser.Visible = true;
               
            }
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "IsActive")
            {
                ShowFilteredRows();
            }
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedItem = dataGridUsers.SelectedRows[0].Cells[0].Value;
            int userID = Convert.ToInt32(selectedItem);
            clsUser user = clsUser.FindUser("UserID", userID);
                frm_ChangePassword changePassword = new frm_ChangePassword(user);
                changePassword.Show();
            
        }
        private void showDetaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedItem = dataGridUsers.SelectedRows[0].Cells[0].Value;
            int userID = Convert.ToInt32(selectedItem);
            clsUser user = clsUser.FindUser("UserID", userID);
            frmUserDetails userDetails = new frmUserDetails(user);
            userDetails.Show();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedItem = dataGridUsers.SelectedRows[0].Cells[0].Value;
            int userID = Convert.ToInt32(selectedItem);
            
            if (clsUser.DeleteUser(userID))
            {
                MessageBox.Show("The user is deleted successfuly");
                RefereshUsersList();
            }else
            {
                MessageBox.Show("The user not deleted");
            }
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser addUser = new frmAddUser();
            addUser.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object selectedItem = dataGridUsers.SelectedRows[0].Cells[0].Value;
            int userID = Convert.ToInt32(selectedItem);
            clsUser user = clsUser.FindUser("UserID",userID);
            frmAddUser editUser = new frmAddUser(user);
            editUser.Show();
        }
    }
}

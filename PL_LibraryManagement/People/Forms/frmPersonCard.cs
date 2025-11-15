using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL_LibraryManagement.People.Forms
{
    public partial class frmPersonCard : Form
    {
        public event Action<int> SelectedPersonID;
        private int _PersonID = 0;
        public frmPersonCard()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ctrPersonCard1._btnClose.Visible = false;

            this.Padding = new Padding(05,05,05,05);
            this.BackColor = AppColors.Primary;
            tableLayoutPanel1.BackColor = AppColors.Background;
            this.btnClose.BackColor = Color.Red;
            label1.ForeColor = AppColors.TextDark;
            label2.ForeColor = AppColors.TextDark;
            
            
        }

        public void SetPersonData(PersonService person)
        {
            ctrPersonCard1.LoadPerson(person);
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text;
            if (!int.TryParse(query, out int personID)) 
                return;
            
           PersonService person = PersonService.FindPersonByID(personID);
            
            if (person != null)
            {
                _PersonID = person.PersonID;
                ctrPersonCard1.LoadPerson(person);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_PersonID <= 0) { 
                MessageBox.Show("invalid Person id!");
                return;  
            }
            SelectedPersonID?.Invoke(_PersonID);
            this.Close();
            this.Dispose();
        }
    }
}

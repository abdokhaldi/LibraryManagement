using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL_LibraryManagement.People.UserControls
{
    public partial class ctrAddEditPerson : UserControl
    {
        private enum Mode {Add,Update }
        private Mode _Mode = Mode.Add;

        public event Action OnClose;

        private PersonService _SelectedPerson ;
        public event Action<PersonService> CardInfoUpdated;
        public event Action DataGridRefreshed;

        
        public ctrAddEditPerson()
        {
            InitializeComponent();
            SetupUI();
            rbMale.Checked = true;
            _Mode = Mode.Add;
        }
        public ctrAddEditPerson(PersonService person)
        {
            InitializeComponent();
            SetupUI();

            _Mode = Mode.Update;
            _SelectedPerson = person;
        }
        
       private void SetupTextBoxesUI()
        {
            foreach(Control pl in this.plForm.Controls){
                foreach (Control ctr in pl.Controls)
                {
                    if (ctr is TextBox || ctr is RadioButton)
                    {
                        this.flowLayoutPanel1.BackColor = Color.Red;
                        ctr.Padding = new Padding(8, 5, 5, 5);
                        ctr.Font = AppFonts.Normal;
                        ctr.ForeColor = AppColors.TextDark;
                    }
                }
            }
        }


        private void SetupUI()
        {
            this.plForm.BackColor = AppColors.Background;
            this.BackColor = AppColors.Primary;
            this.gbForm.BackColor = AppColors.Primary;
            this.gbForm.TitleColor = AppColors.Background;
            gbForm.TitleFont = AppFonts.GbText;
            this.lblPersonID.ForeColor = AppColors.Primary;
            this.chkBox.ForeColor = AppColors.Primary;
            this.plGender.ForeColor = AppColors.Primary;
            this.btnSave.BackColor = AppColors.Accent;
            this.btnClose.BackColor = AppColors.Danger;
            gbForm.Padding = new Padding(5,15,5,5);
            gbForm.BorderColor = AppColors.Primary;
            SetupTextBoxesUI();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke();
        }

        private void FillPersonToSave(PersonService person)
        {
            person.FirstName = txtFirstName.Text;
            person.LastName = txtLastName.Text;
            person.Phone = txtPhone.Text;
            person.Email = txtEmail.Text;
            person.Address = txtAddress.Text;
            person.City = txtCity.Text;
            person.Gender = rbMale.Checked? 'M' : 'F';
            person.IsActive = true;
        }

        private void EditPersonToSave(PersonService person)
        {
            person.tempPersonID = Convert.ToInt32(lblPersonID.Text);

            person.FirstName = txtFirstName.Text;
            person.LastName = txtLastName.Text;
            person.Phone = txtPhone.Text;
            person.Email = txtEmail.Text;
            person.Address = txtAddress.Text;
            person.City = txtCity.Text;
            person.Gender = rbMale.Checked ? 'M' : 'F';
            person.IsActive = true;
        }

        private void BeReadyAfterAdding(OperationResultBLL result, PersonService person)
        {
            if (result.Success)
            {
                MessageBox.Show(result.Message);
                if (_Mode == Mode.Add)
                {
                    lblPersonID.Text = person.PersonID.ToString();
                    gbForm.Text = "Update :";

                    _Mode = Mode.Update;
                    _SelectedPerson = person;
                }
                DataGridRefreshed?.Invoke();
                CardInfoUpdated?.Invoke(person);
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            PersonService person;
            if (_Mode == Mode.Add)
            {
                person = new PersonService();
                FillPersonToSave(person);
            }
            else
            {
                 person = _SelectedPerson;
                EditPersonToSave(person);
            }

            OperationResultBLL result = person.Save();
            BeReadyAfterAdding(result, person);
        }

        private void LoadSelectedPersonToForm()
        {
            lblPersonID.Text = _SelectedPerson.PersonID.ToString();
            txtFirstName.Text = _SelectedPerson.FirstName;
            txtLastName.Text = _SelectedPerson.LastName;
            txtPhone.Text = _SelectedPerson.Phone;
            txtEmail.Text = _SelectedPerson.Email;
            txtAddress.Text = _SelectedPerson.Address;
            txtCity.Text = _SelectedPerson.City;
            rbMale.Checked = (_SelectedPerson.Gender =='M');
            rbFemale.Checked = (_SelectedPerson.Gender == 'F');
            rbFemale.Checked = (_SelectedPerson.Gender == 'F');
            rbFemale.Checked = (_SelectedPerson.Gender == 'F');
            chkBox.Checked = _SelectedPerson.IsActive; 
        }
        private void ctrAddEditPerson_Load(object sender, EventArgs e)
        {
            if (_Mode == Mode.Update)
            {
                gbForm.Text = "Update :";
                LoadSelectedPersonToForm();
            }else
            {
                gbForm.Text = "Add :";
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsValidSymbolsForAddress(char c)
        {
            return (c != ' ' && c != ',' && c != '.' && c != '/' && c != '#');
        }
        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!char.IsControl(c) && !char.IsLetterOrDigit(c) && IsValidSymbolsForAddress(c)) 
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar!='+' )
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsControl(c) && !char.IsLetterOrDigit(c) && c!='@' && c!='.')
            {
                e.Handled = true;
            }
        }
    }
}

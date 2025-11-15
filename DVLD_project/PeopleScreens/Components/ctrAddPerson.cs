using DVLD_BussinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;




namespace DVLD_project.People.Components 
{
    public partial class ctrAddPerson : UserControl
    {
        private Label _lblLogo;
       // private clsPerson _personID ;

        public event EventHandler btn_close
        {
            add { btnClose.Click += value; }
            remove { btnClose.Click -= value; }
        }
        public event EventHandler btn_save{
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }
        public string lbl_PersonID
        {
            get { return lblPersonID.Text; }
            set { lblPersonID.Text = value; }
        }
        
        public ctrAddPerson()
        {
            InitializeComponent();

        }
        public ctrAddPerson(clsPerson person)
        {

            InitializeComponent();
         //  _personID = person;
         //  _personID = personID;
        }

        public void SetFormLabel(Label lblLogo)
        {
            lblLogo = _lblLogo;
        }

        public void UpdateFormLabel(string text)
        {
            if (_lblLogo != null)
            {
                _lblLogo.Text = text;
            }
        }

        public void LoadUpdateFormData(clsPerson person)
        {
            if (person == null)
            {
                MessageBox.Show("Person object is null.");
                return;
            }

            // Make sure the form has the controls initialized before accessing them
            if (txtNationalNo == null || rbMale == null || rbFemale == null)
            {
                MessageBox.Show("One or more controls on the form are null.");
                return;
            }
            //  frmAddNewPerson.lbl_Logo_Title = "Update Person";
            lblPersonID.Text = person.PersonID.ToString();
            txtNationalNo.Text = person.NationalNo;
            txtFirstName.Text = person.FirstName;
            txtSecondName.Text = person.SecondName;
            txtThirdName.Text = person.ThirdName;
            txtFourthName.Text = person.LastName;
            txtEmail.Text = person.Email;
            txtPhone.Text = person.Phone;
            dtDateOfBirth.Value = (DateTime)person.DateOfBirth;

            /*if (person.Gendor == 0)
            {
                rbMale.Checked = true;
            }
            else if (person.Gendor == 1)
            {
                rbFemale.Checked = true;
            }
*/
            txtAddress.Text = person.Address;
            cbCountry.SelectedValue = person.CountryID;
            pbProfileImage.ImageLocation = person.ImagePath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsPerson person;
            if (int.TryParse(lblPersonID.Text, out int personID))
            {
                person = clsPerson.FindPerson("PersonID",personID);
                if (person != null)
                {
                    person.NationalNo = txtNationalNo.Text;
                    person.FirstName = txtFirstName.Text;
                    person.SecondName = txtSecondName.Text;
                    person.ThirdName = txtThirdName.Text;
                    person.LastName = txtFourthName.Text;
                    person.Email = txtEmail.Text;
                    person.Phone = txtPhone.Text;
                    person.DateOfBirth = dtDateOfBirth.Value;
                    /*if (rbMale.Checked)
                    {
                        person.Gendor = 0;  
                    }
                    if (rbFemale.Checked)
                    {
                        person.Gendor = 1;
                    }*/
                    person.Address = txtAddress.Text;
                    person.CountryID = (int)cbCountry.SelectedValue;
                    person.ImagePath = pbProfileImage.ImageLocation;


                }
            }
            else
            {
                person = new clsPerson();

                person.NationalNo = txtNationalNo.Text;
                person.FirstName = txtFirstName.Text;
                person.SecondName = txtSecondName.Text;
                person.ThirdName = txtThirdName.Text;
                person.LastName = txtFourthName.Text;
                person.Email = txtEmail.Text;
                person.Phone = txtPhone.Text;
                person.DateOfBirth = dtDateOfBirth.Value;
                /*if (rbMale.Checked)
                {
                    person.Gendor = 0;
                }
                if (rbFemale.Checked)
                {
                    person.Gendor = 1;
                }*/
                person.Address = txtAddress.Text;
                person.CountryID = (int)cbCountry.SelectedValue;
                person.ImagePath = pbProfileImage.ImageLocation;
            }
            if (person._Mode == clsPerson.enMode.AddNew) { 
                 ShowSaveMessageResult(person, "Added");
             }else
            {
                ShowSaveMessageResult(person, "Updated");
            }
        }

        private void ShowSaveMessageResult(clsPerson person, string message)
        {
            if (person.Save())
            {
                if (person._Mode==clsPerson.enMode.Update) {
                    MessageBox.Show($"the person {person.PersonID} {message} successfuly !", "message", MessageBoxButtons.OK);
                    
                    lblPersonID.Text = person.PersonID.ToString();
                    LoadUpdateFormData(person);
                }
                else
                {
                    MessageBox.Show($"the person {person.PersonID} {message} successfuly !", "message", MessageBoxButtons.OK);
                }
            }
           else
                {
                    MessageBox.Show($"faild to {message} the person!");
                }
        }
           
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbProfileImage.Image = Image.FromFile("C:/DVLD_images/user_male.png");
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbProfileImage.Image = Image.FromFile("C:/DVLD_images/user_Female.png");
        }

        private void ctrAddPerson_Load(object sender, EventArgs e)
        {
            DataTable dt = clsPerson.GetCountriesList();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.DataSource = dt;

            DateTime today = DateTime.Now;
            DateTime allowedBirthOfDate = today.AddYears(-18);
            dtDateOfBirth.MaxDate = allowedBirthOfDate;


            rbMale.Checked = true;
        }

        private void lkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;
                pbProfileImage.ImageLocation = imagePath;
            }
        }

        private void lkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbProfileImage.ImageLocation = "";
        }
        private void validateTextBox(TextBox control, string fieldName,string txtBoxText,string errorMessage,CancelEventArgs e)
        {
            
                if (clsPerson.checkIfFieldExisting(fieldName, txtBoxText))
                {
                    errorProvider1.SetError(control, errorMessage);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    errorProvider1.SetError(control, "");
                }
            }
        

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == txtNationalNo)
            {
                validateTextBox(textBox, "NationalNo", txtNationalNo.Text, "this National number is already exist",e);
            }
            if (textBox == txtPhone)
            {
                validateTextBox(textBox, "Phone",txtPhone.Text, "this Phone number is already exist",e);
            }
            if (textBox == txtEmail)
            {
                validateTextBox(textBox, "Email", txtEmail.Text, "this Email is already exist",e);
            }
        }

    }
}

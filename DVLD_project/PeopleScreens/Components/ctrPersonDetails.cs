using DVLD_BussinessLayer;
using DVLD_project.ComonUserControls;
using DVLD_project.People.Forms;
using System.Windows.Forms;

namespace DVLD_project.People.Components
{
    
    public partial class ctrPersonDetails : UserControl
    {

        private clsPerson _SelectedPerson;
        
        public int SelectedPersonID
        {
            get { return _SelectedPerson.PersonID; }
        }
        public ctrPersonDetails()
        {
            InitializeComponent();
           
        }
        
        private void _LoadImagePath(clsPerson person)
        {
            if (person.ImagePath != null)
            {
                pbProfileImage.ImageLocation = person.ImagePath;
                return;
            }
            else
            {
                MessageBox.Show("Missing profile image for this _SelectedPerson!", "Image path",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            /*if (person.Gendor == 0)
            {
                pbProfileImage.Image = Properties.Resources.user_male;
            }else
            {
                pbProfileImage.Image = Properties.Resources.user_female;
            }*/
        }

        public void FillPersonInfo(int personID)
        {
             _SelectedPerson = clsPerson.FindPerson("PersonID", personID);
            if (_SelectedPerson != null)
            {
                
                lblPersonID.Text = _SelectedPerson.PersonID.ToString();
                lblName.Text = _SelectedPerson.FirstName + " " + _SelectedPerson.SecondName + " " + _SelectedPerson.ThirdName + " " + _SelectedPerson.LastName;
                lblNatinalNo.Text = _SelectedPerson.NationalNo;
                lblNatinalNo.Text = _SelectedPerson.NationalNo;
                //lblGendor.Text = (_SelectedPerson.Gendor==0?"Male":"Female");
                lblEmail.Text = _SelectedPerson.Email;
                lblAddress.Text = _SelectedPerson.Address;
                lblDateOfBirth.Text = _SelectedPerson.DateOfBirth.Value.ToString("dd-MM-yyy");
                lblPhone.Text = _SelectedPerson.Phone;
                lblCountry.Text = clsCountry.FindCountryById(_SelectedPerson.CountryID).CountryName;
                if (_SelectedPerson.ImagePath != "")
                {
                    pbProfileImage.ImageLocation = _SelectedPerson.ImagePath;
                }
                _LoadImagePath(_SelectedPerson);
                
                
            }
        }
        public void FillPersonInfo(string nationalNo)
        {
            _SelectedPerson = clsPerson.FindPerson("NationalNo", nationalNo);
            if (_SelectedPerson != null)
            {

                lblPersonID.Text = _SelectedPerson.PersonID.ToString();
                lblName.Text = _SelectedPerson.FirstName + " " + _SelectedPerson.SecondName + " " + _SelectedPerson.ThirdName + " " + _SelectedPerson.LastName;
                lblNatinalNo.Text = _SelectedPerson.NationalNo;
              //  lblGendor.Text = (_SelectedPerson.Gendor == 0 ? "Male" : "Female");
                lblEmail.Text = _SelectedPerson.Email;
                lblAddress.Text = _SelectedPerson.Address;
                lblDateOfBirth.Text = _SelectedPerson.DateOfBirth.Value.ToString("dd-MM-yyy");
                lblPhone.Text = _SelectedPerson.Phone;
                lblCountry.Text = clsCountry.FindCountryById(_SelectedPerson.CountryID).CountryName;
               _LoadImagePath(_SelectedPerson);


            }
        }
        
 private void lkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_SelectedPerson != null)
            {
                frmAddNewPerson newPerson = new frmAddNewPerson(null, _SelectedPerson);
                newPerson.Show();
            }else
                MessageBox.Show("The person card info is empty!");
        }

        private void pbProfileImage_Click(object sender, System.EventArgs e)
        {

        }

        private void label33_Click(object sender, System.EventArgs e)
        {

        }
    }
}

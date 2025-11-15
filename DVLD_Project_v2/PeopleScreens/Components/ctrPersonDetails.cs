using DVLD_BussinessLayer;
using DVLD_project.ComonUserControls;
using DVLD_project.People.Forms;
using DVLD_project.UserScreens.Components;
using DVLD_Project_v2.PeopleScreens.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.People.Components
{

    public partial class ctrPersonDetails : UserControl
    {

        private clsPerson _SelectedPerson;
        public clsPerson SelectedPerson
        {
            get { return _SelectedPerson; }
        }
        public int SelectedPersonID
        {
           get
            {
                if (_SelectedPerson==null)
                {
                    return -1;
                }
                return _SelectedPerson.PersonID;
                
            } 
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
                MessageBox.Show("Missing profile image for this SelectedPerson!", "Image path",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            if (person.Gender == 0)
            {
                pbProfileImage.Image = Properties.Resources.user_male;
            }else
            {
                pbProfileImage.Image = Properties.Resources.user_female;
            }
        }

        public void FillPersonInfo(int personID)
        {
             _SelectedPerson = clsPerson.FindPerson("PersonID", personID);
            if (_SelectedPerson == null)
            {
                MessageBox.Show($"The person with ID:{personID} not found","Not Found");
                return;
            }

                lblPersonID.Text = SelectedPerson.PersonID.ToString();
                lblName.Text = SelectedPerson.FirstName + " " + SelectedPerson.SecondName + " " + SelectedPerson.ThirdName + " " + SelectedPerson.LastName;
                lblNatinalNo.Text = SelectedPerson.NationalNo;
                lblNatinalNo.Text = SelectedPerson.NationalNo;
                lblGendor.Text = (SelectedPerson.Gender==0?"Male":"Female");
                lblEmail.Text = SelectedPerson.Email;
                lblAddress.Text = SelectedPerson.Address;
                lblDateOfBirth.Text = SelectedPerson.DateOfBirth.Value.ToString("dd-MM-yyy");
                lblPhone.Text = SelectedPerson.Phone;
                lblCountry.Text = clsCountry.FindCountryById(SelectedPerson.CountryID).CountryName;
                if (SelectedPerson.ImagePath != "")
                {
                    pbProfileImage.ImageLocation = SelectedPerson.ImagePath;

                }
                _LoadImagePath(SelectedPerson);
             }
        
        public void FillPersonInfo(string nationalNo)
        {

            _SelectedPerson = clsPerson.FindPerson("NationalNo", nationalNo);
            if (_SelectedPerson == null)
            {
                MessageBox.Show($"The person with National No:{nationalNo} not found", "Not Found");
                return;
            }

            lblPersonID.Text = SelectedPerson.PersonID.ToString();
                lblName.Text = SelectedPerson.FirstName + " " + SelectedPerson.SecondName + " " + SelectedPerson.ThirdName + " " + SelectedPerson.LastName;
                lblNatinalNo.Text = SelectedPerson.NationalNo;
                lblNatinalNo.Text = SelectedPerson.NationalNo;
                lblGendor.Text = (SelectedPerson.Gender == 0 ? "Male" : "Female");
                lblEmail.Text = SelectedPerson.Email;
                lblAddress.Text = SelectedPerson.Address;
                lblDateOfBirth.Text = SelectedPerson.DateOfBirth.Value.ToString("dd-MM-yyy");
                lblPhone.Text = SelectedPerson.Phone;
                lblCountry.Text = clsCountry.FindCountryById(SelectedPerson.CountryID).CountryName;
                if (SelectedPerson.ImagePath != "")
                {
                    pbProfileImage.ImageLocation = SelectedPerson.ImagePath;
                }
                _LoadImagePath(SelectedPerson);

        }
        

        private void lkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lkEditPersonInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson editPerson = new frmAddUpdatePerson();
            editPerson.ShowDialog();
        }
    }
}

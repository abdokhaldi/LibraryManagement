using DVLD_BussinessLayer;
using DVLD_project.People.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.People.Forms
{
   
    public partial class frmAddNewPerson : Form
    {
        public delegate void PersonAddedHandler(int personID);
        public event PersonAddedHandler PersonAdded;

        private frmManagePeople managePeople;
        private clsPerson _person;

        public string lbl_Logo_Title
        {
            get { return lblLogoTitle.Text; }
            set { lblLogoTitle.Text=value; }
        }



        public frmAddNewPerson(frmManagePeople form1, clsPerson person)
        {
            InitializeComponent();
            this.managePeople = form1;
            this._person = person;
            
            ctrAddPerson1.LoadUpdateFormData(_person);
            ctrAddPerson1.btn_close += btnClose_clic;
            ctrAddPerson1.btn_save += btnSave_click;

        }
        public frmAddNewPerson(frmManagePeople frm)
        {
            
           InitializeComponent();
            this.managePeople = frm;
            ctrAddPerson1.btn_close += btnClose_clic;
            ctrAddPerson1.btn_save += btnSave_click;
        }
        public frmAddNewPerson()
        {

            InitializeComponent();
            
            ctrAddPerson1.btn_close += btnClose_clic;
            ctrAddPerson1.btn_save += btnSave_click;
        }
        public frmAddNewPerson(clsPerson person)
        {

            InitializeComponent();
            _person = person;
            ctrAddPerson1.LoadUpdateFormData(_person);
            ctrAddPerson1.btn_close += btnClose_clic;
            ctrAddPerson1.btn_save += btnSave_click;
        }


        private void btnClose_clic(object sender, EventArgs e)
        {
            int newPerson = Convert.ToInt32(ctrAddPerson1.lbl_PersonID);
            PersonAdded?.Invoke(newPerson);
            managePeople.RefereshPeopleList();
            this.Close();
        }
        private void btnSave_click(object sender,EventArgs e)
        {
            if (int.TryParse(ctrAddPerson1.lbl_PersonID, out int personID)){
               lblLogoTitle.Text = "Update Person";
            }
            
        }
       
        private void frmAddNewPerson_Load(object sender, EventArgs e)
        {
            
            if (_person != null)
            {
                lblLogoTitle.Text = "Update Person";
            }
            else { 

                lblLogoTitle.Text = "Add New Person";
            }

        }

        private void ctrAddPerson1_Load(object sender, EventArgs e)
        {

        }
    }
}

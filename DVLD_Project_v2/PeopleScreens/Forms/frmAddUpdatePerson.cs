using DVLD_BussinessLayer;
using DVLD_project.People.Components;
using DVLD_project.People.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project_v2.PeopleScreens.Forms
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void PersonAddedHandler(int personID);
        public event PersonAddedHandler OnPersonAdded;

        private frmManagePeople _managePeople;
        private clsPerson _person;

        public string lbl_Logo_Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        public frmAddUpdatePerson(frmManagePeople managePeople, int personID)
        {
            InitializeComponent();
            this._managePeople = managePeople;
            this._person = clsPerson.FindPerson("PersonID", personID);

            ctrAddPerson1.LoadUpdateFormData(_person);
            ctrAddPerson1.btn_close += btnClose_click;
            ctrAddPerson1.btn_save += btnSave_click;

        }
        public frmAddUpdatePerson(frmManagePeople managePeople)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this._managePeople = managePeople;
            ctrAddPerson1.btn_close += btnClose_click;
            ctrAddPerson1.btn_save += btnSave_click;
        }
        public frmAddUpdatePerson()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ctrAddPerson1.btn_close += btnClose_click;
            ctrAddPerson1.btn_save += btnSave_click;
        }
        public frmAddUpdatePerson(clsPerson person)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _person = person;
            ctrAddPerson1.LoadUpdateFormData(_person);
            ctrAddPerson1.btn_close += btnClose_click;
            ctrAddPerson1.btn_save += btnSave_click;
        }
        private void btnClose_click(object sender, EventArgs e)
        {
            if (!int.TryParse(ctrAddPerson1.lbl_PersonID, out int personID))
            {
                this.Close();
                return;
            }
            int newPersonID = Convert.ToInt32(ctrAddPerson1.lbl_PersonID);
            OnPersonAdded?.Invoke(newPersonID);
            _managePeople.RefereshPeopleList();
            this.Close();
        }
        private void ctrAddPerson1_Load(object sender, EventArgs e)
        {

        }
        private void btnSave_click(object sender, EventArgs e)
        {
            if (int.TryParse(ctrAddPerson1.lbl_PersonID, out int personID))
            {
                lblTitle.Text = "Update Person";
            }
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            if (_person != null)
            {
                lbl_Logo_Title = "Update Person";
            }
            else
            {

                lbl_Logo_Title = "Add New Person";
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


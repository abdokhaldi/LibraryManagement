using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.LicensClass;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.Users;
using DVLD_DataAccess.ApplicationTypes;
using DVLD_project.DrivingLicenseServicesScreens.NewDrivingLicense.LocalLicense;
using DVLD_project.PeopleScreens.Components;
using DVLD_project.UserScreens.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications
{
    public partial class frmAddUpdateApplication : Form
    {
        public  delegate void EventHandler();
        public event EventHandler OnRefreshLDLApplicationList;
       public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLDLApplications _LocalDrivingLicenseApplication;
        
        public frmAddUpdateApplication()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

        }

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.LicenseClassesList();
            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();


            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLDLApplications();
                // tbpApplicationInfo.Enabled = false;
                
                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationType.FindApplicationType(1).ApplicationTypeFeese.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tbpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;


            }

        }

        private void _LoadData()
        {

            _LocalDrivingLicenseApplication  = clsLDLApplications.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
               
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            ctrAddPersonWithFilter1._LoadPersonData(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblDVLApplicationID.Text= _LocalDrivingLicenseApplication.LDLApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).LicenseClassName) ;
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindUser("UserID",_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }

      private void DataBackEvent(object sender, int PersonID)
      {
          // Handle the data received
          _SelectedPersonID = PersonID;
          ctrAddPersonWithFilter1._LoadPersonData(PersonID);
      }

        private void frmAddUpdateApplication_1_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }
        // person id comes from ctrAddPersonWithFilter1 as label string
       
        private void btnNext_Click_1(object sender, EventArgs e)
        {
           if (_Mode == enMode.Update)
              {
                btnSave.Enabled = true;
                tbpApplicationInfo.Enabled = true;
                tbApplication.SelectedTab = tbApplication.TabPages["tbpApplicationInfo"];
                return;
            }
          

            //incase of add new mode.
            if (ctrAddPersonWithFilter1.SelectedPersonID != -1)
            {

                btnSave.Enabled = true;
                tbpApplicationInfo.Enabled = true;
                tbApplication.SelectedTab = tbApplication.TabPages["tbpApplicationInfo"];

            }
          else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
               ctrAddPersonWithFilter1.txtFilter.Focus();
            }
        }

        
        private void btnSave_Click_1(object sender, EventArgs e)
        {


            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            short LicenseClassID = (short)clsLicenseClass.FindLicenseClassID(cbLicenseClass.Text);


            int ActiveApplicationID = clsLDLApplications.GetActiveApplicationIDForLicenseClass(_SelectedPersonID,LicenseClassID) ; 

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }


            //check if person already have issued license of the same driving  class.
           if (clsLicense.IsPersonHasLicenseClass(_SelectedPersonID, LicenseClassID))
          {
             MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
           }
            _LocalDrivingLicenseApplication.ApplicantPersonID = _SelectedPersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewLocal;
            _LocalDrivingLicenseApplication.ApplicationStatus = (int)clsApplication.enStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID =  clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            

            bool isSaved = _LocalDrivingLicenseApplication.Save();
            if (isSaved)
            {
                lblDVLApplicationID.Text = _LocalDrivingLicenseApplication.LDLApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnRefreshLDLApplicationList?.Invoke();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        

        private void frmAddUpdateLocalDrivingLicesnseApplication_Activated(object sender, EventArgs e)
        {
            ctrAddPersonWithFilter1.txtFilter.Focus();
        }

        private void ctrAddPersonWithFilter1_OnSelectedPerson(int obj)
        {
            _SelectedPersonID = obj;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

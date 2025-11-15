using DVLD_BussinessLayer.Users;
using DVLD_project.PeopleScreens.Components;
using DVLD_project.UserScreens.Components;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DVLD_project.UserScreens.Forms
{
    public partial class frmAddUpdateUser : Form
    {
        private enum enMode {AddNew=1,Update=2 }
        private enMode Mode;
        private clsUser _User;
        private int _UserID = -1;
        private int _SelectedPersonID=-1;
       
        
        public frmAddUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddUpdateUser( int userID)
        {
            InitializeComponent();
            _UserID = userID;
            Mode = enMode.Update;
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            ctrAddPersonWithFilter1.cbFilter.SelectedIndex = 1;
            ctrAddPersonWithFilter1.txtFilter.Focus();
            
            _ResetDefaultValues();
           
            if (Mode == enMode.Update)
            {
                ctrAddPersonWithFilter1.gbFilterEnabled = false;
                _LoadUserData();
            }
         
        }

       private void _ResetDefaultValues(){
            
            if (Mode == enMode.AddNew)
            {
                _User = new clsUser();
                lblTitle.Text = "Add New User";
                tbLoginInfo.Enabled = false;
            
            }
                
            }
       private void _LoadUserData()
        {
            
            _User = clsUser.FindUser("UserID", _UserID);
            if (_User == null)
            {
                MessageBox.Show($"No User Exist with ID:{_UserID}");
            }
            lblTitle.Text = "Update User";
            ctrAddPersonWithFilter1._LoadPersonData(_User.PersonID);
            ctrLoginInfo1.LoadUserData(_User);
        } 
        

       

        private void btnClose_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrLoginInfo1 == null)
            {
                MessageBox.Show("Could not save empty fields!");
               return;
            }
                
           
            _User.PersonID = _SelectedPersonID;
            _User.UserName = ctrLoginInfo1.txtUserName;
            _User.Password = ctrLoginInfo1.txtPassword;
            _User.IsActive = ctrLoginInfo1.chbIsActive;

            bool IsSaved = _User.Save();
            MessageHelper.ShowMessageResult(IsSaved, $"The user [{_User.UserID}] was Saved successfully", "Saving the user was failed !");

            if (IsSaved)
                if (Mode == enMode.AddNew)
                {
                    ctrLoginInfo1.lblUserID = _User.UserID.ToString();
                    Mode = enMode.Update;
                    lblTitle.Text = "Update User";
                }
            btnSave.Enabled = false;
             }                    
                

        private void ctrAddPersonWithFilter1_OnSelectedPerson_1(int obj)
        {
            _SelectedPersonID = obj;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tbLoginInfo.Enabled = true;
                tbUser.SelectedTab = tbUser.TabPages["tbLoginInfo"];
                
                return;
            }
            if (_SelectedPersonID != -1)
            {
                btnSave.Enabled = true;
                tbLoginInfo.Enabled = true;
                tbUser.SelectedTab = tbUser.TabPages["tbLoginInfo"];
            } else
            {
                MessageBox.Show("Select a person fist!");
                ctrAddPersonWithFilter1.txtFilter.Focus();
            }

        }
    }
  }
    


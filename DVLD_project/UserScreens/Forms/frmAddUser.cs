using DVLD_BussinessLayer.Users;
using DVLD_project.People.Components;
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

namespace DVLD_project.UserScreens.Forms
{
    public partial class frmAddUser : Form
    {
        private clsUser _user;
       // private frmManageUser _manageUser;
        private ctrLoginInfo loginInfoControl;
        
        public frmAddUser()
        {
            InitializeComponent(); 
        }
        public frmAddUser( clsUser user)
        {

            InitializeComponent();
            
            this._user = user;
           // this._addPersonWithFilter = new ctrAddPersonAsUser();
          // _addPersonWithFilter.ctr_personDetail.FillPersonInfo("PersonID",_user.PersonID);
            
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            btnPersonalInfo.PerformClick();
        }

       

        private void loginInfo_click(object sender, EventArgs e)
        {
            Control controlToKeep = btnNext;
            for (int i = splitContainer1.Panel2.Controls.Count - 1; i >= 0; i--)
            {
                Control control = splitContainer1.Panel2.Controls[i];
                if (control != controlToKeep)
                {
                    splitContainer1.Panel2.Controls.Remove(control);
                }else
                {
                    control.Visible = false;
                }
            }
             loginInfoControl = new ctrLoginInfo();
            splitContainer1.Panel2.Controls.Add(loginInfoControl);
            
                btnLoginInfo.BackColor = Color.White;
            
                btnPersonalInfo.BackColor = Color.LightGray;
            if (_user != null)
            {
                loginInfoControl.lbl_UserID = _user.UserID.ToString();
                loginInfoControl.txt_UserName = _user.UserName;
                loginInfoControl.txt_Password = _user.Password;
                loginInfoControl.txt_ConfirmPassword = _user.Password;
                loginInfoControl.cb_IsActive = _user.IsActive;
            }
            
        }
        private void DisableNext_SaveButton(bool isEnabled)
        {
            btnNext.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
        }
        private void btnPersonalInfo_Click(object sender, EventArgs e)
        {

            Control controlToKeep = btnNext;
            for (int i=splitContainer1.Panel2.Controls.Count-1;i>=0;i--)
            {
                Control control = splitContainer1.Panel2.Controls[i];
                if (control != controlToKeep)
                {
                    splitContainer1.Panel2.Controls.Remove(control);
                }else
                {
                    control.Visible = true;
                }
            }
            if (_user != null)
            {
                lbl_AddUserLogo.Text = "Update User";
               // AddNewUserControl = new ctrAddPersonWithFilter1(_user.PersonID);
                
                btnLoginInfo.BackColor = Color.LightGray;
                btnPersonalInfo.BackColor = Color.White;
            }
            else
            {
                lbl_AddUserLogo.Text = "Add New User";

                btnLoginInfo.BackColor = Color.LightGray;
                btnPersonalInfo.BackColor = Color.White;
                
            }

            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnLoginInfo.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsUser user;
            if (loginInfoControl == null)
            {
                MessageBox.Show("Please fill in the login information first.");
                return;
            }

            if (int.TryParse(loginInfoControl.lbl_UserID.ToString(), out int userID))
            {
                user = clsUser.FindUser("UserID", userID);

                /*       if (int.TryParse(AddNewUserControl.ctr_personDetail.lbl_PersonID, out int personID))
                       {
                           user.PersonID = personID;
                       }
                       user.UserName = loginInfoControl.txt_UserName;
                       user.Password = loginInfoControl.txt_Password;
                       user.IsActive = loginInfoControl.cb_IsActive;
                       if (user.Save())
                       {
                           MessageBox.Show($"The user {user.UserID} Updated successfuly");
                       }
                       else  
                       {
                           MessageBox.Show($"Updating the user was failed");
                       }
                   }
                   else
                   {
                       user = new clsUser();

                       user.PersonID = Convert.ToInt32(AddNewUserControl.ctr_personDetail.lbl_PersonID);
                       user.UserName = loginInfoControl.txt_UserName;
                       user.Password = loginInfoControl.txt_Password;
                       user.IsActive = loginInfoControl.cb_IsActive;
                       if (user.Save())
                       {
                           MessageBox.Show($"The user {user.UserID} added successfuly");
                           loginInfoControl.lbl_UserID = user.UserID.ToString();
                           lbl_AddUserLogo.Text = "Update User";
                       }
                       else
                       {
                           MessageBox.Show($"Adding the user was failed");
                       }
                   }
                */
            }
        }

        }
    }


using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Users;
using DVLD_project.Applications;
using DVLD_project.ApplicationTypeScreens;
using DVLD_project.Drivers;
using DVLD_project.DrivingLicenseServicesScreens;
using DVLD_project.DrivingLicenseServicesScreens.Detain_ReleaseLicense;
using DVLD_project.DrivingLicenseServicesScreens.InternationalDriverLicense;
using DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications;
using DVLD_project.People.Forms;
using DVLD_project.Renew;
using DVLD_project.TestTypeScreens;
using DVLD_project.UserScreens;
using DVLD_project.UserScreens.Forms;
using DVLD_Project_v2.DrivingLicenseServicesScreens.InternationalDriverLicense;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class frmHomeScreen : Form
    {
        
        private clsUser _UserInfo ;
        public frmHomeScreen(clsUser userInfo)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            setMdiBackgroundColor(Color.Black);
            _UserInfo = userInfo;
         }
        
        private void setMdiBackgroundColor(Color color)
        {
            foreach (Control ctr  in this.Controls)
            {
                if (ctr is MdiClient)
                {
                    ctr.BackColor = color;
                }
            }
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople managePeople = new frmManagePeople();
            //managePeople.MdiParent = this;
            managePeople.ShowDialog();
            
        }
  private void _AdjustToolStripMenuItemsDropDown(ToolStripMenuItem[] menuItemsList)
    {
     for (int i=0;i<menuItemsList.Length;i++)
         {
            foreach (ToolStripMenuItem childItem in menuItemsList[i].DropDownItems)
            {
                childItem.AutoSize = false;
                childItem.ImageScaling = ToolStripItemImageScaling.None;

                // Assuming childItem.Image is not null; otherwise, check for null first
                if (childItem.Image != null)
                {
                    childItem.Image = new Bitmap(childItem.Image, new Size(40, 40));
                }

                childItem.Size = new Size(300, 50);
             }

          }

        }
        private void frmHomeScreen_Load(object sender, EventArgs e)
        {
            
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.AutoSize = false;
                item.ImageScaling = ToolStripItemImageScaling.None;
                item.Image = new Bitmap(item.Image, new Size(60, 60));
                item.Size = new Size(220,100);
            }
            this.BackColor = Color.Black;

            _AdjustToolStripMenuItemsDropDown(new ToolStripMenuItem[]{applicationsToolStripMenuItem,settingsToolStripMenuItem});
        }

        

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUser manageUser = new frmManageUser();
          //  manageUser.MdiParent = this;
            manageUser.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails userDetails = new frmUserDetails(_UserInfo);
            userDetails.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(_UserInfo);
            changePassword.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form loginForm = Application.OpenForms["frmLogin"];
            foreach (Form openForm in Application.OpenForms.Cast<Form>().ToList())
            {
                if (openForm != loginForm)
                {
                    openForm.Close();
                }
            }

            if (loginForm != null)
            {
                loginForm.Show();
            }else
            {
                loginForm = new frmLogin();
                loginForm.Show();
            }
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmManageApplicationTypes manageApplicationTypes;
            manageApplicationTypes = new frmManageApplicationTypes();
            manageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes manageTestTypes = new frmManageTestTypes();
            manageTestTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmAddUpdateApplication newLocalLicense = new frmAddUpdateApplication();
            newLocalLicense.Show();
        }

       
        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDLApplications manageApplication =
                new frmManageLDLApplications();
           // manageApplication.MdiParent = this;
            manageApplication.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers manageDrivers = new frmManageDrivers();
           // manageDrivers.MdiParent = this;
            manageDrivers.Show();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalDriverLicenseApplication
                international = new frmInternationalDriverLicenseApplication();
            international.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLDVLicense renewLicense = new frmRenewLDVLicense();
            renewLicense.Show();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacement replacement =
                new frmReplacement();
            replacement.Show();
        }

        

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense releaseLicense = new frmReleaseLicense();
            releaseLicense.Show();
        }

        private void detaineLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.Show();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense releaseLicense = new frmReleaseLicense();
            releaseLicense.Show();
        }

        private void manageDetaiedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses manageDetainedLicenses =
                new frmManageDetainedLicenses();
            manageDetainedLicenses.Show();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDLApplications manageLDLApps = new frmManageLDLApplications();
            manageLDLApps.Show();
        }

        private void internationalLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenses internationalLicense =
                new frmManageInternationalLicenses();
            internationalLicense.ShowDialog();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

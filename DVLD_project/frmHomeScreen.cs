using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Users;
using DVLD_project.Applications;
using DVLD_project.ApplicationTypeScreens;
using DVLD_project.Drivers;
//using DVLD_project.DrivingLicenseServices.NewDrivingLicense.LocalLicense;
using DVLD_project.DrivingLicenseServicesScreens;
using DVLD_project.DrivingLicenseServicesScreens.Detain_ReleaseLicense;
using DVLD_project.DrivingLicenseServicesScreens.InternationalDriverLicense;
using DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications;
using DVLD_project.People.Components;
using DVLD_project.People.Forms;
using DVLD_project.Renew;
using DVLD_project.TestTypeScreens;
using DVLD_project.UserScreens;
using DVLD_project.UserScreens.Components;
using DVLD_project.UserScreens.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class frmHomeScreen : Form
    {
        private string _username;
        public frmHomeScreen(string username)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            setMdiBackgroundColor(Color.Black);
            _username = username;
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
            managePeople.MdiParent = this;
            managePeople.Show();
            
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

            foreach (ToolStripMenuItem childItem in licencesToolStripMenuItem.DropDownItems)
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

            foreach (ToolStripMenuItem childItem in settingsToolStripMenuItem.DropDownItems)
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUser manageUser = new frmManageUser();
            manageUser.MdiParent = this;
            manageUser.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindUser("UserName",_username);
            frmUserDetails userDetails = new frmUserDetails(user);
            userDetails.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindUser("UserName",_username);
            frm_ChangePassword changePassword = new frm_ChangePassword(user);
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
            manageApplicationTypes.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes manageTestTypes = new frmManageTestTypes();
            manageTestTypes.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // frmAddUpdateLocalLicense newLocalLicense = new frmAddUpdateLocalLicense();
            // newLocalLicense.Show();
            frmAddUpdateApplication newLocalLicense = new frmAddUpdateApplication();
            newLocalLicense.Show();
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDLApplications manageApplication =
                new frmManageLDLApplications();
            manageApplication.Show();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers manageDrivers = new frmManageDrivers();
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

        private void detainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void licencesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense releaseLicense = new frmReleaseLicense();
            releaseLicense.Show();
        }

        private void detaineLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.Show();*/
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
    }
}

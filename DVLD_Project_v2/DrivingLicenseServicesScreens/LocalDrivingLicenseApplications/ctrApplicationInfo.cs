using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.LicensClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.DrivingLicenseServicesScreens.NewDrivingLicense.LocalLicense
{
    public partial class ctrApplicationInfo : UserControl
    {
        public string lbl_DVLApplicationID
        {
            set { lblDVLApplicationID.Text = value; }
            get { return lblDVLApplicationID.Text; }
        }
        public string lbl_ApplicationDate
        {
            set { lblApplicationDate.Text = value; }
            get { return lblApplicationDate.Text; }
        }
        public ComboBox cb_LicenseClass
        {
           // set { cbLicenseClass = value; }
            get { return cbLicenseClass; }
        }
        public string lbl_ApplicationFees
        {
            set { lblApplicationFees.Text = value; }
            get { return lblApplicationFees.Text; }
        }
        public string lbl_CreatedBy
        {
            set { lblCreatedBy.Text = value; }
            get { return lblCreatedBy.Text; }
        }
        private int _ldlAppID = 0;

        public ctrApplicationInfo()
        {
            InitializeComponent();
        }
        public ctrApplicationInfo(int ldlAppID)
        {
            InitializeComponent();
            _ldlAppID = ldlAppID;
        }
        
     private void ctrApplicationInfo_Load(object sender, EventArgs e)
        {
              DataTable dt = clsLicenseClass.LicenseClassesList();
                cbLicenseClass.DisplayMember = "ClassName";
                cbLicenseClass.ValueMember = "LicenseClassID";
                cbLicenseClass.DataSource = dt;
                lblApplicationDate.Text = DateTime.Now.ToString("dd-MM-yyy");
                lbl_ApplicationFees = "15";
                string createdBy = clsSharedCurrentUserInfo.currentUserInfo.UserInfo.UserName;
                lblCreatedBy.Text = createdBy;
                cbLicenseClass.SelectedIndex = 2;
            } 
        }

        
    }


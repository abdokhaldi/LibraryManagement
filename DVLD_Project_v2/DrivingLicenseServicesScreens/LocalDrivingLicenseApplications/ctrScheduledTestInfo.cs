using DVLD_BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications.ctrDLApplicationInfo;

namespace DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications
{
    public partial class ctrScheduledTestInfo : UserControl
    {

        // private ctrDLApplicationInfo.stScheduleInfo _scheduleInfo;
        public ctrScheduledTestInfo()
        {
            InitializeComponent();
           
        }

        public void FillAppointmentInfo(ref ctrDLApplicationInfo.stScheduleInfo _scheduleInfo)
        {
            lblDLAppID.Text = _scheduleInfo.LDLAppID.ToString();
            lblDClass.Text = _scheduleInfo.LicenseClassName;
            lblName.Text = _scheduleInfo.ApplicantFullName;
            lblTrial.Text = _scheduleInfo.Trial.ToString();
            lblDate.Text = _scheduleInfo.Date;
            lblFees.Text = _scheduleInfo.Fees.ToString();
        }

        private void ctrScheduledTestInfo_Load(object sender, EventArgs e)
        {

        }
    }
    
}

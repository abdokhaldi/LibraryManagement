using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.LicensClass;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.Users;
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

namespace DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications
{
    public partial class ctrDLApplicationInfo : UserControl
    {
        private int _personID = 0;
        clsLDLApplications _ldlApplicationInfo ;

        public struct stScheduleInfo
        {
            public int ApplicationID;
            public int LDLAppID;
            public string LicenseClassName;
            public string ApplicantFullName;
            public short PassedTest;
            public short Trial;
            public string Date;
            public Decimal Fees;
            public int createdByUserID;
            public int TestTypeID;
            public int PersonID;
            public int LicenseClassID;
            public Decimal LicenseClassFees ;
        }
        private stScheduleInfo _scheduleInfo;
        
        public ctrDLApplicationInfo()
        {
            InitializeComponent();
            _scheduleInfo = new stScheduleInfo();
        }

        /// <summary>
        /// FillDLApplicationInfo() 
        /// </summary>
        /// <param name="ldlApplicationInfo"> is full LocalDrivingLicenseApplication object passed to fill properties </param>
        public void FillDLApplicationInfo(clsLDLApplications ldlApplicationInfo)
        {
            if (ldlApplicationInfo != null)
            {
               
                _personID = ldlApplicationInfo.ApplicantPersonID;
                lblDLAppID.Text = ldlApplicationInfo.LDLApplicationID.ToString();
                lblClassName.Text = ldlApplicationInfo.LicenseClassInfo.LicenseClassName;
                lblPassedTest.Text = clsTest.CountAllPassedTestsForCurrentLDLApplication(ldlApplicationInfo.LDLApplicationID).ToString() +"/3";
                lblID.Text = ldlApplicationInfo.ApplicationID.ToString();
                lblStatus.Text = ldlApplicationInfo.ApplicationStatus.ToString();
                lblFees.Text = ldlApplicationInfo.PaidFees.ToString();
                lblType.Text = ldlApplicationInfo.ApplicationTypeInfo.ApplicationTypeTitle;
                lblApplicant.Text = ldlApplicationInfo.ApplicantPersonFullName;
                lblDate.Text = ldlApplicationInfo.ApplicationDate.ToString("dd-mm-yyy");
                lblStatusDate.Text = ldlApplicationInfo.LastStatusDate.ToString("dd-mm-yyy");
                lblCreatedBy.Text = ldlApplicationInfo.UserInfo.UserName;
                _ldlApplicationInfo = ldlApplicationInfo;
            }
            else
            {
                lblDLAppID.Text = "";
                lblClassName.Text = "";
                lblPassedTest.Text = "";
            }
        }

        /// <summary>
        /// FillDLApplicationInfo()
        /// </summary>
        /// <param name="ldlAppID"> is an integer parameter pased as localDrivingLicenseID to find the current ldlApplication</param>
        public void FillDLApplicationInfo(int ldlAppID)
        {
            clsLDLApplications ldlApplicationInfo = clsLDLApplications.FindLocalDrivingLicenseApplicationByID(ldlAppID);
            if (ldlApplicationInfo != null)
            {

                _personID = ldlApplicationInfo.ApplicantPersonID;
                lblDLAppID.Text = ldlApplicationInfo.LDLApplicationID.ToString();
                lblClassName.Text = ldlApplicationInfo.LicenseClassInfo.LicenseClassName;
                lblPassedTest.Text = clsTest.CountAllPassedTestsForCurrentLDLApplication(ldlApplicationInfo.LDLApplicationID).ToString() + "/3";
                lblID.Text = ldlApplicationInfo.ApplicationID.ToString();
                lblStatus.Text = ldlApplicationInfo.ApplicationStatus.ToString();
                lblFees.Text = ldlApplicationInfo.PaidFees.ToString();
                lblType.Text = ldlApplicationInfo.ApplicationTypeInfo.ApplicationTypeTitle;
                lblApplicant.Text = ldlApplicationInfo.ApplicantPersonFullName;
                lblDate.Text = ldlApplicationInfo.ApplicationDate.ToString("dd-mm-yyy");
                lblStatusDate.Text = ldlApplicationInfo.LastStatusDate.ToString("dd-mm-yyy");
                lblCreatedBy.Text = ldlApplicationInfo.UserInfo.UserName;
                _ldlApplicationInfo = ldlApplicationInfo;
            }
            else
            {
                lblDLAppID.Text = "";
                lblClassName.Text = "";
                lblPassedTest.Text = "";
            }
        }

        public stScheduleInfo FillScheduleInfoAsStruct()
        {
            
            string[] parts = lblPassedTest.Text.Trim().Split('/');
            _scheduleInfo.LDLAppID = Convert.ToInt32(lblDLAppID.Text);
            _scheduleInfo.LicenseClassName = _ldlApplicationInfo.LicenseClassInfo.LicenseClassName ;
            _scheduleInfo.LicenseClassID = _ldlApplicationInfo.LicenseClassID;
            _scheduleInfo.LicenseClassFees = _ldlApplicationInfo.LicenseClassInfo.ClassFees;
            _scheduleInfo.ApplicantFullName = lblApplicant.Text;
            _scheduleInfo.PassedTest = Convert.ToInt16(parts[0]);
            _scheduleInfo.Date = lblDate.Text;
            _scheduleInfo.Fees = (_scheduleInfo.PassedTest == 0)? 10 : (_scheduleInfo.PassedTest == 1) ? 20 : (_scheduleInfo.PassedTest == 2) ? 30 : (_scheduleInfo.PassedTest == 3)?(short)_scheduleInfo.LicenseClassFees:0;
            _scheduleInfo.createdByUserID = _ldlApplicationInfo.UserInfo.UserID;
            _scheduleInfo.TestTypeID = (_scheduleInfo.PassedTest == 0) ? 1 : (_scheduleInfo.PassedTest == 1) ? 2 : (_scheduleInfo.PassedTest == 2) ? 3 : 0;
            _scheduleInfo.Trial = clsTest.CountTestResultsForCurrentTestType(_scheduleInfo.LDLAppID, 0, Convert.ToInt16(_scheduleInfo.TestTypeID)) ;
           _scheduleInfo.ApplicationID = _ldlApplicationInfo.ApplicationID;
            _scheduleInfo.PersonID = _ldlApplicationInfo.ApplicantPersonID;
            
            return _scheduleInfo;
        }
       private void lklPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
            
            frmPersonDetails personDetails = new frmPersonDetails(_personID);
                personDetails.Show();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblDLAppID_Click(object sender, EventArgs e)
        {

        }
    }
}

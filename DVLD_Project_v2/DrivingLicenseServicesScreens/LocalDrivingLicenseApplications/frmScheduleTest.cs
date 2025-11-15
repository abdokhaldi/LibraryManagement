using DVLD_BussinessLayer;
using DVLD_DataAccess.ApplicationTypes;
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
    public partial class frmScheduleTest : Form
    {
        public delegate void EventHandler();
        public event EventHandler OnAppointmentListReferesh;
        private  ctrDLApplicationInfo.stScheduleInfo _scheduleInfo;

        // passsed via constractor to check if comes with -1 then it addNewMode if _ID>0 then updateMode
         private int _testAppointmentID;
         private short _testTypeID;
        public frmScheduleTest(ctrDLApplicationInfo.stScheduleInfo scheduleInfo, int testAppointmentID
            , short testTypeID) 
        {
            InitializeComponent();
            _scheduleInfo = scheduleInfo;
            _testAppointmentID = testAppointmentID;
            _testTypeID = testTypeID; 
        }

       
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            if (_testTypeID == 1)
            {
                pbScheduleLogo.Image = Properties.Resources.eye;
            }
            else if (_testTypeID == 2)
            {
                pbScheduleLogo.Image = Properties.Resources.exam_2_;
            }
            else
            {
                pbScheduleLogo.Image = Properties.Resources.black_car_1_;
            }

            lblSatMessage.AutoSize = true;
            if (_testAppointmentID != -1 && clsTestAppointment.FindTestAppointmentByID(_testAppointmentID).IsLocked)
            {
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                lblSatMessage.Text = "Person already sat for the test,Appointment locked";
            }
            
            lblDLAppID.Text = _scheduleInfo.LDLAppID.ToString();
            lblDClass.Text = _scheduleInfo.LicenseClassName;
            lblName.Text = _scheduleInfo.ApplicantFullName;
            lblTrial.Text = _scheduleInfo.Trial.ToString();
            dtpDate.Value = DateTime.Now;
            lblFees.Text = _scheduleInfo.Fees.ToString();
            
            if (_scheduleInfo.Trial > 0)
            {
                lblRetakeTitle.Visible = true;
                gbRetakeTestInfo.Enabled = true;
                lblRetakeAppTestFees.Text = "5";
                lblTotalFees.Text = (int.TryParse(lblRetakeAppTestFees.Text.Trim(), out int retakFees) && int.TryParse(lblFees.Text.Trim(), out int fees)) ? (retakFees + fees).ToString() : "0";
                lblFees.Text = lblTotalFees.Text;
            }
            else
            {
                lblRetakeTitle.Visible = false;
            }

         }
        
       
        private void _AddNewAppointment()
        {
            clsTestAppointment appointment = new clsTestAppointment(_scheduleInfo.Trial);
            //for retake test application
            appointment.ApplicantPersonID = _scheduleInfo.PersonID;
            appointment.ApplicationDate = DateTime.Now;
            appointment.ApplicationTypeID = 7;
            appointment.ApplicationStatus = 3;
            appointment.LastStatusDate = DateTime.Now;
            appointment.PaidFees = clsApplicationType.FindApplicationType(7).ApplicationTypeFeese;
            appointment.CreatedByUserID = _scheduleInfo.createdByUserID;

            // for appointment
            appointment.TestTypeID = _testTypeID ;
            appointment.LocalDLApplicationID = _scheduleInfo.LDLAppID;
            appointment.AppointmentDate = dtpDate.Value;
            if (_scheduleInfo.Trial >0)
            {
                appointment.AppPaidFees = Convert.ToInt16(lblTotalFees.Text);
            }
            else
            {
                appointment.AppPaidFees = _scheduleInfo.Fees;
            }
            appointment.IsLocked = false;

            bool success = appointment.Save();
            MessageHelper.ShowMessageResult(success, "the appointment was added successfully", "Adding appointment was failed");
            if (success)
            {
                OnAppointmentListReferesh?.Invoke();
            }
            this.Close();
        }
        private void _UpdateAppointment()
        {
            
              clsTestAppointment  appointment = 
               clsTestAppointment.FindTestAppointmentByID(_testAppointmentID);
            appointment.AppointmentDate = dtpDate.Value;
            bool success = appointment.Save();
            MessageHelper.ShowMessageResult(success, "the appointment was Updated successfully", "Updating appointment was failed");
            if (success)
            {
                OnAppointmentListReferesh?.Invoke();
            }
            this.Close();
        }
        
     private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (_testAppointmentID != -1)
            {
                _UpdateAppointment();
                return;
            }

            _AddNewAppointment();
            }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSchedule_LOGO_Click(object sender, EventArgs e)
        {

        }

        private void pbScheduleLogo_Click(object sender, EventArgs e)
        {

        }
    }
    }


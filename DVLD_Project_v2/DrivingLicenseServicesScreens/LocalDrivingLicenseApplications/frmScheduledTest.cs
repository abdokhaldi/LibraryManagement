using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using System;
using System.Windows.Forms;
using static DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications.ctrDLApplicationInfo;

namespace DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications
{
    public partial class frmScheduledTest : Form
    {
       private stScheduleInfo _scheduleInfo;
        private int _testAppointmentID ;

        public delegate void EventHandler();
        public event EventHandler OnRefreshAppointmentsList;

        private short _testTypeID;
        
        public frmScheduledTest(int testAppointmentID,stScheduleInfo scheduleInfo,short testTypeID)
        {
            InitializeComponent();
            _testAppointmentID = testAppointmentID;
            _scheduleInfo = scheduleInfo;
            ctrScheduleInfo1.FillAppointmentInfo(ref _scheduleInfo);
            _testTypeID = testTypeID;
        }

        private void frmScheduledTest_Load(object sender, EventArgs e)
        {
            
            if (_testTypeID == 1)
            {
                pbScheduledLogo.Image = Properties.Resources.eye;
            }
            else if (_testTypeID == 2)
            {
                pbScheduledLogo.Image = Properties.Resources.exam_2_;
            }
            else
            {
                pbScheduledLogo.Image = Properties.Resources.black_car_1_;
            }
            if (_testAppointmentID != -1 && clsTestAppointment.FindTestAppointmentByID(_testAppointmentID).IsLocked)
            {
                btnSave.Enabled = false;
                rbPass.Enabled = false;
                rbFail.Enabled = false;
                txtNotes.Enabled = false;
            }

        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTest test = new clsTest();
            test.TestAppID = _testAppointmentID;
            test.TestResult = rbPass.Checked;
            test.Notes = txtNotes.Text;
            test.CreatedByUserID = _scheduleInfo.createdByUserID;

            bool isTestSaved = test.AddNewTest();
            MessageHelper.ShowMessageResult(isTestSaved,"The test was taken","the test was not taken");
            
             if (isTestSaved)
               {
                // lock appointment
                bool locked = clsTestAppointment.LockAppointment(_testAppointmentID);
                if (!locked)
                {
                    MessageBox.Show("Lock appointment was Failed","",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    if(_testTypeID==3 && rbPass.Checked)
                    {
                      if(clsApplication.SetComplete(_scheduleInfo.LDLAppID))
                        {
                            OnRefreshAppointmentsList?.Invoke();
                            this.Close();
                            return;
                        }
                        
                    }
                   OnRefreshAppointmentsList?.Invoke();
                   this.Close();
                }
            }else
            {
                MessageBox.Show("Adding test appointment was failed");
                this.Close();
            }
                
                
             
        }
    }
}

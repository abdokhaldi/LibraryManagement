using DVLD_BussinessLayer;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
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
    public partial class frmAppointment : Form
    {
         public  delegate void EventHandler();
         public  event EventHandler OnRefreshLDLAppManagement;

        private int _ldlAppID;
        private short _testTypeID;
        
        public frmAppointment(int ldlAppID, short testTypeID)
        {
            InitializeComponent();
       
            ctrDLApplicationInfo1.FillDLApplicationInfo(ldlAppID);
            _ldlAppID = ldlAppID;
            _testTypeID = testTypeID;
           
        }

        /// <RefreshTestAppointmentsList>
        /// to load Test Appointments on test appointments screen 
        
        public void RefreshTestAppointmentsList()
        {
            dataGridAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Retrieve data from the database
            DataTable dtTestAppointments = clsTestAppointment.FindAppointmentByLDLAppID(_ldlAppID, _testTypeID);
            
            DataView dtv = dtTestAppointments.DefaultView;
            // Display record count
            dataGridAppointments.DataSource = dtv;
            lblRecords.Text = dtv.Count.ToString();
            OnRefreshLDLAppManagement?.Invoke();
                
        }
        /// </RefreshTestAppointmentsList>

        private void frmAppointment_Load(object sender, EventArgs e)
        {
            if (_testTypeID == 1)
            {  
                pbApp_LOGO.Image = Properties.Resources.eye;
                lblApp_LOGO.Text = "Vision Test Appointment";
                
            }
            else if(_testTypeID == 2)
            {
                pbApp_LOGO.Image = Properties.Resources.exam_2_;
                lblApp_LOGO.Text = "Written Test Appointment";
                
            }
            else
            {
                pbApp_LOGO.Image = Properties.Resources.black_car_1_;
                lblApp_LOGO.Text = "Street Test Appointment";
               
            }

            RefreshTestAppointmentsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            bool isPass = clsTest.CountTestResultsForCurrentTestType(_ldlAppID, 1, _testTypeID) > 0;
            if (isPass)
            {
              MessageBox.Show("can't add more appointments for this test because the person is passed for this test", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                if (clsTestAppointment.NumberOfTestAppointmentStates(_ldlAppID, false) == 0)
                {
                    frmScheduleTest scheduleTest = new frmScheduleTest( ctrDLApplicationInfo1.FillScheduleInfoAsStruct(), -1, _testTypeID);
                    scheduleTest.OnAppointmentListReferesh += RefreshTestAppointmentsList;
                    scheduleTest.Show();
                }
                else
                {
                    MessageBox.Show("Adding a test appointment for this driving license application is Disable because he already has an open appontment", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
                
       
        }

      private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           int testAppointmentID = (int)dataGridAppointments.SelectedRows[0].Cells[0].Value;

              frmScheduleTest scheduleTest = new frmScheduleTest(ctrDLApplicationInfo1.FillScheduleInfoAsStruct(), testAppointmentID,_testTypeID);
              scheduleTest.Show();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int testAppointmentID = (int)dataGridAppointments.SelectedRows[0].Cells[0].Value;

            frmScheduledTest takeTest = new frmScheduledTest(testAppointmentID, ctrDLApplicationInfo1.FillScheduleInfoAsStruct(), _testTypeID);
            takeTest.OnRefreshAppointmentsList += RefreshTestAppointmentsList;
            takeTest.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
          //  bool locked = (bool)dataGridAppointments.SelectedRows[0].Cells[4].Value;
         
        }
    }
    }


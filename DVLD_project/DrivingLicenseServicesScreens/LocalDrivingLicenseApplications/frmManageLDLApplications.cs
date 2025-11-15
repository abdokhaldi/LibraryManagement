using DVLD_BussinessLayer;
using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
//using DVLD_project.DrivingLicenseServices.NewDrivingLicense.LocalLicense;
using DVLD_project.DrivingLicenseServicesScreens;
using DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;


namespace DVLD_project.Applications
{
    public partial class frmManageLDLApplications : Form
    {
        private static DataGridView _dataGridLDVApplications;
        private static Label _lblRecords;
        
        public frmManageLDLApplications()
        {
            InitializeComponent();
            _dataGridLDVApplications = dataGridLDVApplications;
            _lblRecords = lblRecords;
        }
        enum enTestType { VisionTest=1, WrittenTest=2, StreetTest=3 }
        enum enCurrentCell {NULL,LDLAppID,PassedTest,NationalNo}

        // _CurrentCell(enCurrentCell cell) : to get the current cell value in data grid view
        // dependent of enum : enCurrentCell
        private object _CurrentCell(enCurrentCell cell)
        {
            object currentCell=0;
           
           
        switch (cell)
            {
                 case enCurrentCell.LDLAppID:
                  //  represents localDrivingLicenseApplicationID
                    currentCell = dataGridLDVApplications.SelectedRows[0].Cells[0].Value;
                    break;
                case enCurrentCell.PassedTest:
                    // represents Passed test
                    currentCell = dataGridLDVApplications.SelectedRows[0].Cells[5].Value;
                    break;
                case enCurrentCell.NationalNo :
                    // represents the national Number
                    currentCell = dataGridLDVApplications.SelectedRows[0].Cells[2].Value;
                    break;
                case enCurrentCell.NULL:
                    // represents no item selected
                    if(dataGridLDVApplications.SelectedRows.Count==0)
                     currentCell = null;
                    break;
                    ;
            }
            return currentCell;
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtSearchApplication.Visible = false;
                RefreshLDLApplicationsListStatic();
            } else
            {
                txtSearchApplication.Visible = true;
            }
        }
         public static void RefreshLDLApplicationsListStatic(object o = null)
         {
             _dataGridLDVApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
             DataTable dt = clsLDLApplications.GetLDLApplicationsList(); 
             _dataGridLDVApplications.DataSource = dt;
             _lblRecords.Text = dt.Rows.Count.ToString();
         }
        public void RefreshLDLApplicationsList()
          {
         
              RefreshLDLApplicationsListStatic(null);
         }
        private void frmManageLDLApplication_Load(object sender, EventArgs e)
        {

            txtSearchApplication.Visible = false;
            RefreshLDLApplicationsListStatic();
        }
        private void Filter(string filteredBy, DataView dv)
        {
            string filterText = txtSearchApplication.Text;

            switch (filteredBy)
            {
                case "L.D.L.AppID":
                    if (int.TryParse(filterText, out int applicationID))
                    {
                        dv.RowFilter = $"LocalDrivingLicenseApplicationID = {applicationID}";
                    }
                    else
                    {
                        dv.RowFilter = ""; // Clear filter if input is invalid
                    }
                    break;

                case "FullName":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}%'";
                    break;
                case "NationalNo":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}%'";
                    break;

                case "ApplicationStatus":
                    dv.RowFilter = $"{filteredBy} LIKE '%{filterText}'";
                    break;
            }
            dataGridLDVApplications.DataSource = dv;
        }
        private void ShowFilterRows()
        {
            DataTable dt = clsLDLApplications.GetLDLApplicationsList();
            DataView dv = dt.DefaultView;

            Filter(cbFilterBy.Text, dv);
        }
        private void txtSearchApplication_TextChanged(object sender, EventArgs e)
        {
            ShowFilterRows();
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateApplication newLocalLicenseApplication = new frmAddUpdateApplication();
            //newLocalLicenseApplication += RefreshLDLApplicationsList;
            newLocalLicenseApplication.Show();
        }

        bool IsApplicationInProcess()
        {
            return (Convert.ToInt16(_CurrentCell(enCurrentCell.PassedTest)) > 0);
        }
        private void _DeleteApplication(int ldlApplicationID)
        {
            clsLDLApplications ldlApplication = clsLDLApplications.FindLocalDrivingLicenseApplicationByID(ldlApplicationID);
            bool isDeleted = ldlApplication.Delete();
            if (MessageHelper.SowMessageConform("Are you sure you want to delete this application"))
            {
                MessageHelper.ShowMessageResult(isDeleted, "The application was deleted successfully", "the application was not deleted");
                if (isDeleted)
                {
                    RefreshLDLApplicationsList();
                }
            }
            else
                MessageBox.Show("the deletion was cancelled");
        }
        private void _CancelApplication(int ldlApplicationID)
        {
            
                if (MessageHelper.SowMessageConform("Are you sure to cancel this application"))
                {
                    bool isCancelled = clsApplication.SetCancel(ldlApplicationID);
                    MessageHelper.ShowMessageResult(isCancelled, "the application Was Canceled", "the application could Not be Canceled");
                    if (isCancelled)
                    {
                        RefreshLDLApplicationsList();
                    }

                }
                else
                {
                    MessageBox.Show("The Cancellation Was Cancelled");
                }
            
        }

        private void ManageApplicationActions(object sender, EventArgs e)
        {
            if (_CurrentCell(enCurrentCell.NULL)==null)
            {
                // this function is to check if any iten selected in data grid view or not
                MessageHelper.ShowMessageResult(true, "Please select an application first.", "");
                return;
            }

            try
            {
                if (sender is ToolStripMenuItem Item)
                {
                    int ldlAppID = (int)_CurrentCell(enCurrentCell.LDLAppID);
                    if (Item == deleteApplicationToolStripMenuItem)
                    {
                        _DeleteApplication(ldlAppID);
                    }
                    else if (Item == cancelApplicationToolStripMenuItem)
                    {
                        if(!IsApplicationInProcess())
                            _CancelApplication(ldlAppID);
                        else
                        {
                            MessageBox.Show("you can't cancel an application in process!","",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        }
                    }
                } else
                {
                    MessageBox.Show("Unexpected action source.");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessageResult(true, "An error occurred: " + ex.Message, "");
            }
        }

        



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// /TestStepState : handle test steps in toolStripeMenu Items
        /// </summary>
        /// <param name="visionTest"> when current step is vision test make it enabled </param>
        /// <param name="writtenTest">when current step is written  test make it enabled</param>
        /// <param name="streetTest"> when current step is street test make it enabled</param>
        void TestStepState(bool[] scheduleItemEnabledStates)
        {
            short itemsCount = (short)sechduleTestToolStripMenuItem.DropDownItems.Count;
            if (scheduleItemEnabledStates.Length != itemsCount)
            {
                throw new Exception($"The number of items in scheduleItemEnabledStates must match the number of DropDownItems ({itemsCount}).");
            }
            
            ToolStripDropDownItem[] scheduleItems = new ToolStripDropDownItem[itemsCount];
            sechduleTestToolStripMenuItem.DropDownItems.CopyTo(scheduleItems,0);
            for (int i=0;i<itemsCount;i++)
            {
                scheduleItems[i].Enabled = scheduleItemEnabledStates[i];
            }
        }
        
       private void _ContextMenuItemsEnabling(bool[] bools)
        {
            for (int i=0;i<contextMenuStrip1.Items.Count;i++)
            {
                contextMenuStrip1.Items[i].Enabled = bools[i];
            }
        }

        void toolStripMenuItemCheckedBools(bool Enabled=true,short i=-1)
        {
            if (i != -1)
            {
                _ContextMenuItemsEnabling(new bool[] { true, false, false, false, false, false, true, true });
            }
            else
            {
                _ContextMenuItemsEnabling(new bool[] { true, true, true, true, true, false, false, true });
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            string status = dataGridLDVApplications.SelectedRows[0].Cells[6].Value.ToString();
            if (status == "Cancelled")
            {
                // if the application is cancelled
                _ContextMenuItemsEnabling(new bool[] {true, false, true, false, false, false, false, true});
                return;
            }
            int passedTest = (int)_CurrentCell(enCurrentCell.PassedTest);
            if (passedTest == 0) 
                // if current test is vision
            {
                toolStripMenuItemCheckedBools();
                // to enable open vision test and disable written and street test
                TestStepState(new bool[] { true, false, false });
                return;
            }
            if (passedTest == 1) // if current test is written
            {
                // to enable open written test and disable vision and street test

                toolStripMenuItemCheckedBools();
                TestStepState(new bool[] { false, true, false });
                return;
            }
             if (passedTest == 2) // if current test is street
            {
                // to enable open streen test and disable vision and written test
                toolStripMenuItemCheckedBools();
                TestStepState(new bool[] { false, false, true });
                return;
            }
            if (passedTest == 3)
            {
                toolStripMenuItemCheckedBools(false);
                int ldlAppID = (int)_CurrentCell(enCurrentCell.LDLAppID);

                if (clsLicense.LicenseExistsByAppID(ldlAppID))
                {
                    toolStripMenuItemCheckedBools(true,0);
                }
                else
                {
                    toolStripMenuItemCheckedBools(false, 0);
                }
            }
        }


        void _ScheduleTest(enTestType testType)
        {
            int ldlAppID = (int)_CurrentCell(enCurrentCell.LDLAppID);
           
            frmAppointment appointment = new frmAppointment(ldlAppID, (short)testType);
            appointment.OnRefreshLDLAppManagement += RefreshLDLApplicationsList;
            appointment.Show();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(enTestType.VisionTest);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(enTestType.WrittenTest);
        }

      private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(enTestType.StreetTest);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ldlAppID = (int)_CurrentCell(enCurrentCell.LDLAppID);
            frmIssueDriverLicenseFirstTime issueDriverLicense =
                new frmIssueDriverLicenseFirstTime(ldlAppID, 1);
            issueDriverLicense.Show();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nationalNo = _CurrentCell(enCurrentCell.NationalNo).ToString();
            int personID = clsPerson.FindPerson("NationalNo",nationalNo).PersonID;
            frmLicenseHistory licenseHistory = new frmLicenseHistory(personID);
            licenseHistory.Show();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int ldlAppID = (int)_CurrentCell(enCurrentCell.LDLAppID) ;
             int licenseID =  clsLDLApplications.FindLocalDrivingLicenseApplicationByID(ldlAppID).GetActiveLicenseID();
            if (licenseID == -1)
            {
                MessageBox.Show("Non active license exists for this License!");
                return;
            }

            frmDriverLicenseInfo driverLicenseInfo =
                new frmDriverLicenseInfo(licenseID);
            driverLicenseInfo.Show();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int ldlAppID = (int)_CurrentCell(enCurrentCell.LDLAppID);
           
           // frmAddUpdateApplication newLocalLicense = new frmAddUpdateApplication(ldlAppID);
           // newLocalLicense.Show();
        }
    }
}

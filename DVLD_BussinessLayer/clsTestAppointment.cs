using DVLD_BussinessLayer.Applications;
using DVLD_DataAccess.LocalDrivingLicenseApplications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsTestAppointment : clsApplication
    {
        public enum enMode { AddNewAppointment, UpdateAppointment }
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDLApplicationID { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public Decimal AppPaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        
        public enMode _Mode{get;set;}

        private short _trial = 0;
     private clsTestAppointment(int testAppointmentID, int testTypeID, decimal paidFees,
         int createdByUserID, DateTime? appointmentDate, int localDLApplicationID,bool isLocked)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.AppPaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.AppointmentDate = appointmentDate;
            this.LocalDLApplicationID = localDLApplicationID;
            this.IsLocked = isLocked;
            _Mode = enMode.UpdateAppointment;
        }
        public clsTestAppointment(short trial)
        {
            this.TestAppointmentID = 0;
            this.TestTypeID = 0;
            this.AppPaidFees = 0;
            this.CreatedByUserID = 0;
            this.AppointmentDate = null;
            this.LocalDLApplicationID = 0;
            this.IsLocked = false;
            _Mode = enMode.AddNewAppointment;
            _trial = trial;
        }

        // if appointment is new
    private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = DataAccessTestAppointments.AddNewTestAppointment
                (
                this.TestTypeID,this.LocalDLApplicationID,
                this.AppointmentDate,this.AppPaidFees,
                this.CreatedByUserID,this.IsLocked
                );
            return (this.TestAppointmentID>0);
        }
        // if appointment is retaked
        private bool _AddRetakeTestAppointmentWithApplication()
        {
            this.TestAppointmentID = DataAccessTestAppointments.AddNewTestAppointmentWithApplication
                (this.ApplicantPersonID,this.ApplicationDate,this.ApplicationTypeID,
                this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID,
                this.TestTypeID, this.LocalDLApplicationID,
                this.AppointmentDate, this.AppPaidFees,
                 this.IsLocked
                );
            return (this.TestAppointmentID > 0);
        }

        // add appoint,ent in any case : retaked or new
       private bool SaveAppointment()
        {
            if (_trial > 0)
            {
                return _AddRetakeTestAppointmentWithApplication();
            }
            else
            {
                return _AddNewTestAppointment();
            }
        }


        private bool _UpdateTestAppointment()
        {
            return DataAccessTestAppointments.UpdateTestAppointment(this.TestAppointmentID,this.AppointmentDate);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewAppointment:
                    {
                        if (SaveAppointment())
                        {
                            _Mode = enMode.UpdateAppointment;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.UpdateAppointment:
                    {
                        return _UpdateTestAppointment();
                    }
                }
            return false;
        }

        public static DataTable FindAppointmentByLDLAppID(int ldlAppID,short testTypeID)
        {
          return DataAccessTestAppointments.GetAppointmentByLDLAppID(ldlAppID, testTypeID);
        }


        public static short NumberOfTestAppointmentStates(int ldlAppID, bool isLocked)
        {
            return DataAccessTestAppointments.GetNumberOfTestAppointmentStates(ldlAppID, isLocked);
        }
        public static clsTestAppointment FindTestAppointmentByID(int tstAppID)
        {
            // <tstApp> is a testAppointment found as a dictionary
            Dictionary<string, object> tstApp = DataAccessTestAppointments.GetTestAppointmentByID(tstAppID);
            if (tstApp.Count != 0) {
                try{
                    return new clsTestAppointment(
                       tstApp.ContainsKey("TestAppointmentID") ? (int)tstApp["TestAppointmentID"] : throw new Exception("Missing or Invalid TestAppointmentID"),
                       tstApp.ContainsKey("TestTypeID") ? (int)tstApp["TestTypeID"] : throw new Exception("Missing or Invalid TestTypeID"),
                       tstApp.ContainsKey("PaidFees") ? (Decimal)tstApp["PaidFees"] : throw new Exception("Missing or Invalid PaidFees"),
                       tstApp.ContainsKey("CreatedByUserID") ? (int)tstApp["CreatedByUserID"] : throw new Exception("Missing or Invalid CreatedByUserID"),
                       tstApp.ContainsKey("AppointmentDate") ? (DateTime?)tstApp["AppointmentDate"] : throw new Exception("Missing or Invalid AppointmentDate"),
                       tstApp.ContainsKey("LocalDrivingLicenseApplicationID") ? (int)tstApp["LocalDrivingLicenseApplicationID"] : throw new Exception("Missing or Invalid LocalDrivingLicenseApplicationID"),
                       tstApp.ContainsKey("IsLocked") ? (bool)tstApp["IsLocked"] : throw new Exception("Missing or Invalid IsLocked")
                        );
                }
                catch(Exception ex){
                    Console.WriteLine("Error retrieving test appointment data: " + ex.Message);
                    return null;
                }
            }else
            {
                Console.WriteLine("No data found for the provided TestAppointment ID.");
                return null;
            }
        }
       static public bool LockAppointment(int tstAppID)
        {
            return DataAccessTestAppointments.LockAppointment(tstAppID);
        }
    }
}

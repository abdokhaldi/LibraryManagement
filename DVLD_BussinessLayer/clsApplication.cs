using DVLD_BussinessLayer.Users;
using DVLD_DataAccess.Applications;
using DVLD_DataAccess.ApplicationTypes;
using System;
using System.Collections.Generic;


namespace DVLD_BussinessLayer.Applications
{
    public class clsApplication
    {

        public enum enApplicationType
        {
            NewLocal = 1,
            Renew = 2,
            ReplacementForLost = 3,
            ReplacementForDamaged = 4,
            ReleaseDetained = 5,
            NewInternational = 6
        }
        public enum enMode {AddNew=1,Update=2 }
        public enum enStatus {New=1,Cancel=2,Complete=3}
         
        public clsApplicationType ApplicationTypeInfo;
       public  clsUser UserInfo;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public string ApplicantPersonFullName
        {
            get { return clsPerson.FindPerson("PersonID", ApplicantPersonID).FullName; }
        }
        public DateTime ApplicationDate { get; set; }
        public short ApplicationTypeID { get; set; }
        public short ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public double PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
       
        public enMode Mode { get; set; }
       private clsApplication(int applicationID,int applicantID, DateTime applicationDate, short applicationTypeID,
                           short applicationStatus, DateTime lastStatusDate,
                           double paidFees, int createdBy)
        {
           this.ApplicationID = applicationID;
           this.ApplicantPersonID = applicantID;
           this.ApplicationDate = applicationDate;
           this.ApplicationTypeID = applicationTypeID;
           this.ApplicationStatus = applicationStatus;
           this.LastStatusDate = lastStatusDate;
           this.PaidFees = paidFees;
           this.CreatedByUserID = createdBy;
            ApplicationTypeInfo = clsApplicationType.FindApplicationType(ApplicationTypeID);
           this.UserInfo = clsUser.FindUser("UserID", CreatedByUserID);
           this.Mode = enMode.Update;
        }
        public clsApplication()
        {
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.MinValue;
            ApplicationTypeID =-1;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.MinValue;
            PaidFees = 0;
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

       private bool _AddNewApplication()
        {
            this.ApplicationID =  DataAccessApplications.AddNewApplication(this.ApplicantPersonID,this.ApplicationDate,this.ApplicationTypeID,
                this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
            return ApplicationID != -1;
        }
        private bool _UpdateApplication()
        {
            return DataAccessApplications.UpdateApplication(this.ApplicationID,this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
                this.ApplicationStatus,this.PaidFees, this.LastStatusDate,  this.CreatedByUserID);
        }
        
        public bool Delete(int applicationID)
        {
            int rowsAffected = DataAccessApplications.DeleteApplication(applicationID);
            return (rowsAffected > 0);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateApplication();
            }

            return false;
        }
        public static clsApplication FindApplicationByID(int applicationID)
          {
            // fill a dictionary by values
            Dictionary<string, object> applicationInfo = DataAccessApplications.GetApplicationByID(applicationID);
           
            return new clsApplication
            (
           // extract the dictionary of application info to class
           applicationInfo.ContainsKey("ApplicationID") ? Convert.ToInt32(applicationInfo["ApplicationID"]) : throw new Exception("Missing or invalid ApplicationID"),
           applicationInfo.ContainsKey("ApplicantPersonID") ? Convert.ToInt32(applicationInfo["ApplicantPersonID"]) : throw new Exception("Missing or invalid ApplicantPersonID"),
           applicationInfo.ContainsKey("ApplicationDate") ? Convert.ToDateTime(applicationInfo["ApplicationDate"]) : throw new Exception("Missing or invalid ApplicationDate"),
           applicationInfo.ContainsKey("ApplicationTypeID") ? Convert.ToInt16(applicationInfo["ApplicationTypeID"]) : throw new Exception("Missing or invalid ApplicationTypeID"),
           applicationInfo.ContainsKey("ApplicationStatus") ? Convert.ToInt16(applicationInfo["ApplicationStatus"]) : throw new Exception("Missing or invalid ApplicationStatus"),
           applicationInfo.ContainsKey("LastStatusDate") ? Convert.ToDateTime(applicationInfo["LastStatusDate"]) : throw new Exception("Missing or invalid LastStatusDate"),
           applicationInfo.ContainsKey("PaidFees") ? Convert.ToDouble(applicationInfo["PaidFees"]) : throw new Exception("Missing or invalid PaidFees"),
           applicationInfo.ContainsKey("CreatedByUserID") ? Convert.ToInt32(applicationInfo["CreatedByUserID"]) : throw new Exception("Missing or invalid CreatedByUserID")

            );

        }
        public static bool SetCancel(int ldlApplicationID)
        {
            bool isCanceled =  DataAccessApplications.UpdateApplicationStatus(ldlApplicationID,(short)enStatus.Cancel) > 0;
            return isCanceled;
        }
        public static bool SetComplete(int ldlApplicationID)
        {
            bool isCompleted = DataAccessApplications.UpdateApplicationStatus(ldlApplicationID, (short)enStatus.Complete) > 0;
            return isCompleted ;
        }

    }
}

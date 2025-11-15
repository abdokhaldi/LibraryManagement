using DVLD_BussinessLayer.Driver;
using DVLD_BussinessLayer.LicensClass;
using DVLD_BussinessLayer.LocalDrivingLicenseApplications;
using DVLD_BussinessLayer.Users;
using DVLD_DataAccess.Applications;
using DVLD_DataAccess.ApplicationTypes;
using DVLD_DataAccess.LocalDrivingLicenseApplications;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;


namespace DVLD_BussinessLayer.Applications
{
    public class clsLDLApplications : clsApplication
    {
        public enum enMode {AddNew=1,Update=2 }
        public clsLicenseClass LicenseClassInfo;
        
        public int LDLApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        

        public enMode Mode { get; set; }
         
        private clsLDLApplications(int ldlAppID,int applicationID, int applicantID, DateTime applicationDate, short applicationTypeID,
                           short applicationStatus, DateTime lastStatusDate,
                           double paidFees, int createdByUserID, int licenseClassID)
        {
            this.LDLApplicationID = ldlAppID;
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.LicenseClassID = licenseClassID;
            this.ApplicationTypeInfo = clsApplicationType.FindApplicationType(ApplicationTypeID);
            this.LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(licenseClassID);
            this.UserInfo = clsUser.FindUser("UserID", CreatedByUserID);
            Mode = enMode.Update;
        }
       
        public clsLDLApplications()
        {
            this.LDLApplicationID = -1;
            this.LicenseClassID = -1;
            this.ApplicationID = -1;
            Mode = enMode.AddNew;
        }
        private bool _AddNewLocalDrivingLicenseApplication()
        {
            LDLApplicationID = DataAccessLocalDrivingLicenseApplications.AddNewLocalDrivingLicenseApplication(this.ApplicationID,this.LicenseClassID);
            return (LDLApplicationID!=-1);
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
          return   DataAccessLocalDrivingLicenseApplications.UpdateLocalDrivingLicenseApplication(this.LDLApplicationID,this.ApplicationID, this.LicenseClassID);
             
        }
        public static DataTable GetLDLApplicationsList()
        {
            return DataAccessLocalDrivingLicenseApplications.GetLDLApplacations();
        }
        public static clsLDLApplications FindLocalDrivingLicenseApplicationByID(int ldlAppID)
        {
             int licenseClassID=0, applicationID=0;
            bool isFound = DataAccessLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByID(ldlAppID,ref licenseClassID,ref applicationID);
            if (isFound)
            {
                clsApplication application = clsApplication.FindApplicationByID(applicationID);
                
                return new clsLDLApplications(ldlAppID,application.ApplicationID,application.ApplicantPersonID,
                    application.ApplicationDate,application.ApplicationTypeID,application.ApplicationStatus,
                    application.LastStatusDate,application.PaidFees, application.CreatedByUserID, licenseClassID);
            
            }else
            {
                return null;
            }
        
        }
        
        public static int GetActiveApplicationIDForLicenseClass(int applicantPersonID,short licenseClassID)
        {
            return DataAccessLocalDrivingLicenseApplications.GetActiveApplicationIDForLicenseClass(applicantPersonID,licenseClassID,1);
        }

        public bool _DeleteLocalAndBaseApplication()
        {
            int rowsAffected = DataAccessLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplication(this.LDLApplicationID);
            if (rowsAffected > 0)
            {
                if (base.Delete(this.ApplicationID))
                {
                    return true;
                }
            }
            return false;
        }
      
        // get Active License 
        public int GetActiveLicenseID()
        {
            return DataAccessLicenses.GetActiveLicenseID(this.ApplicantPersonID,this.LicenseClassID);
        }
        public bool Delete()
        {
            return _DeleteLocalAndBaseApplication();
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLocalDrivingLicenseApplication()) { 
                        Mode = enMode.Update;
                        return true;
                    }else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateLocalDrivingLicenseApplication();
                    }   
            }
            return false;
        } 

        public int IssueDrivingLicenseForFirstTime(string note, int createdByUserID)
        {
            clsDriver driver = clsDriver.FindDriverByPersonID(this.ApplicantPersonID);
            int driverID = -1;
            if (driver == null)
            {
                driver = new clsDriver();
                driver.PersonID = this.ApplicantPersonID;
                driver.CreatedByUserID = createdByUserID;
                driver.CreatedDate = DateTime.Now;
                if (driver.Save())
                {
                  driverID = driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }else
            {
                driverID = driver.DriverID;
            }

            clsLicense license = new clsLicense();
            
            license.ApplicationID = this.ApplicationID;
            license.DriverID = driverID;
            license.LicenseClassID = this.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now;
            license.Notes = note;
            license.PaidFees = (double)this.LicenseClassInfo.ClassFees;
            license.IsActive = true;
            license.IssueReason = 1;
            license.CreatedByUserID = createdByUserID;
            if (license.Save())
            {
                return license.LicenseID;
            }
            return -1;
         }
        
    
    
    }
}

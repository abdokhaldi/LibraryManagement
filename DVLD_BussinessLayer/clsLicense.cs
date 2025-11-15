using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.Detain_Release;
using DVLD_BussinessLayer.Driver;
using DVLD_BussinessLayer.LicensClass;
using DVLD_DataAccess.ApplicationTypes;
using DVLD_DataAccess.LocalDrivingLicenseApplications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer.LocalDrivingLicenseApplications
{
    public class clsLicense
    {
        
        public enum enMode {AddNew,Update}
        public enMode Mode { get; set; }
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public double PaidFees { get; set; }
        public bool IsDetained
        {
            get { return clsDetainedReleaseLicense.IsDetainedLicense(this.LicenseID); }
        }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public short IssueReason { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public clsDriver DriverInfo { get; set; }
        public clsDetainedReleaseLicense detainedLicenseInfo { get; set; }
       
        public clsLicense()
        {
           this.LicenseID      = -1;
           this.ApplicationID  = -1;
           this.DriverID       = -1;
           this.ClassName      = "";
           this.IssueDate      = DateTime.MinValue;
           this.ExpirationDate = DateTime.MinValue;
           this.Notes          = "";
           this.IssueReason    = 0;
           this.IsActive =false;
           this.CreatedByUserID = -1;
           
            Mode = enMode.AddNew;
        }
        private clsLicense(int licenseID,int applicationID,int driverID,int licenseClassID,DateTime issueDate,DateTime expirationDate,string notes,double paidFees,bool isActive, short issueReason,int createdByUserID)
        {
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.LicenseClassID = licenseClassID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;
            this.DriverInfo = clsDriver.FindDriverByID(DriverID);
            this.LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(licenseClassID);
            this.detainedLicenseInfo = clsDetainedReleaseLicense.FindByLicenseID(licenseID);
            Mode = enMode.Update;
        }
       
        

        public static clsLicense FindLicenseInfoByID(int licenseID)
        {
            Dictionary<string, object> licenseInfo = new Dictionary<string, object>() ;
                
            if (DataAccessLicenses.GetLicenseInfoByID(licenseID,ref licenseInfo))
            {
                return new clsLicense
                (
                   licenseInfo.ContainsKey("LicenseID") ? (int)licenseInfo["LicenseID"] : throw new Exception("Missing or invalid LicenseID"),
                   licenseInfo.ContainsKey("ApplicationID") ? (int)licenseInfo["ApplicationID"] : throw new Exception("Missing or invalid ApplicalionID"),
                   licenseInfo.ContainsKey("DriverID") ? (int)licenseInfo["DriverID"] : throw new Exception("Missing or invalid DriverID"),
                   licenseInfo.ContainsKey("LicenseClass") ? (int)licenseInfo["LicenseClass"] : throw new Exception("Missing or invalid LicenseClass"),
                   licenseInfo.ContainsKey("IssueDate") ? Convert.ToDateTime(licenseInfo["IssueDate"]) : throw new Exception("Missing or invalid IssueDate"),
                   licenseInfo.ContainsKey("ExpirationDate") ? Convert.ToDateTime(licenseInfo["ExpirationDate"]) : throw new Exception("Missing or invalid ExpirationDate"),
                   licenseInfo.ContainsKey("Notes") ? licenseInfo["Notes"].ToString() : throw new Exception("Missing or invalid Notes"),
                   licenseInfo.ContainsKey("PaidFees") ? Convert.ToDouble(licenseInfo["PaidFees"]) : throw new Exception("Missing or invalid PaidFees"),
                   licenseInfo.ContainsKey("IsActive") ? (bool)licenseInfo["IsActive"] : throw new Exception("Missing or invalid IsActive"),
                   licenseInfo.ContainsKey("IssueReason") ? Convert.ToInt16(licenseInfo["IssueReason"]) : throw new Exception("Missing or invalid IssueReason"),
                   licenseInfo.ContainsKey("CreatedByUserID") ? Convert.ToInt32(licenseInfo["CreatedByUserID"]) : throw new Exception("Missing or invalid CreatedByUserID")
                 );
            }
            else
            {
                return null;
            }
        }

        public static bool LicenseExistsByAppID(int ldlAppID)
        {
            bool licenseExists = DataAccessLicenses.GetCountLicenseBelongsToLDLApp_ByLDLAppID(ldlAppID)>0;
            return licenseExists;
        }
        public static bool LicenseExistsByLicenseID(int licenseID)
        {
            bool licenseExists = DataAccessLicenses.GetCountLicenseByLicenseID(licenseID) > 0;
            return licenseExists;
        }
        public static DataTable GetLicensesHistoryByDriverID(int personID)
        {
            return DataAccessLicenses.GetLicensesHistoryByPersonID(personID);
        }

       private bool _AddNewLicense()
        {
            this.LicenseID = DataAccessLicenses.IssueDriverLicense(
                this.ApplicationID,this.DriverID,this.LicenseClassID,this.IssueDate,this.ExpirationDate,
                this.Notes,this.PaidFees,this.IsActive,this.IssueReason,this.CreatedByUserID
            );
            return (LicenseID != -1);
        }
        private bool _UpdateLicense()
        {
            return true;
           
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLicense())
                        {
                            Mode = enMode.Update;
                            return true;
                        }else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateLicense();
                    }
            }
            return false;
        }
        public bool IsLicenseExpired()
        {
            return (DateTime.Now >= ExpirationDate);
        }
        private bool DesactiveCurrentLicense()
        {
            return (DataAccessLicenses.DesactiveLicense(this.LicenseID));
        }
        public clsLicense RenewLicense(string Notes,int createdByUserID)
        {
           
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplication.enApplicationType.Renew;
            application.ApplicationStatus = (int)clsApplication.enStatus.Complete;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplication.FindApplicationByID(2).PaidFees;
            application.CreatedByUserID = createdByUserID;
            if (!application.Save())
            {
                return null;
            }
            clsLicense newLicense = new clsLicense();
            newLicense.ApplicationID = application.ApplicationID;
            newLicense.DriverID = this.DriverID;
            newLicense.LicenseClassID = this.LicenseClassID;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            newLicense.Notes = Notes;
            newLicense.PaidFees = this.PaidFees;
            newLicense.IsActive = true;
            newLicense.IssueReason = 2;
            newLicense.CreatedByUserID = createdByUserID;
            if (!newLicense.Save())
            {
            return null;
            }
            DesactiveCurrentLicense(); 
            return newLicense;
         }
      
        public static bool IsPersonHasLicenseClass(int personID,int licenseClassID)
        {
            return (DataAccessLicenses.IsPersonHasLicenseClass(personID, licenseClassID));
        }
       
        public  clsLicense Replace(short issueReason, int createdByUserID)
        {
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = (issueReason==3) ? (short)clsApplication.enApplicationType.ReplacementForLost: (short)clsApplication.enApplicationType.ReplacementForDamaged;
            application.ApplicationStatus = (short)clsApplication.enStatus.Complete;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationType.FindApplicationType(issueReason).ApplicationTypeFeese ; 
            application.CreatedByUserID = createdByUserID;
            if (!application.Save())
            {
                return null;
            }
            clsLicense newLicense = new clsLicense();
            newLicense.ApplicationID = application.ApplicationID;
            newLicense.DriverID = this.DriverID;
            newLicense.LicenseClassID = this.LicenseClassID;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = this.ExpirationDate;
            newLicense.Notes = this.Notes;
            newLicense.PaidFees = 0;// no fees for replace license
            newLicense.IsActive = true;
            newLicense.IssueReason = issueReason;
            newLicense.CreatedByUserID = createdByUserID;
            if (!newLicense.Save())
            {
                return null;
            }
            DesactiveCurrentLicense();
            return newLicense;
        }

        public int Detain(int createdUserID, float fineFees)
        {
            clsDetainedReleaseLicense detainLicense = new clsDetainedReleaseLicense();
            detainLicense.LicenseID = this.LicenseID;
            detainLicense.CreatedByUserID = createdUserID;
            detainLicense.DetainDate = DateTime.Now;
            detainLicense.FinFees = fineFees;
            if (!detainLicense.Save())
            {
                return -1;
            }
            return detainLicense.DetainID;
        }
        public bool Release(int createdByUserID,ref int ApplicationID)
        {
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = this.DriverInfo.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.CreatedByUserID = createdByUserID;
            application.ApplicationStatus = (short)clsApplication.enStatus.Complete;
            application.ApplicationTypeID = (short)clsApplication.enApplicationType.ReleaseDetained;
            application.PaidFees = clsApplicationType.FindApplicationType(5).ApplicationTypeFeese;
            application.LastStatusDate = DateTime.Now;
            
            if (!application.Save())
            {
                return false;
            }
            ApplicationID = application.ApplicationID;
            return this.detainedLicenseInfo.ReleaseLicense(createdByUserID,application.ApplicationID);
        }
    }
}

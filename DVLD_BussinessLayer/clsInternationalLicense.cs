using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.Driver;
using DVLD_DataAccess.InternationalLicenses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_BussinessLayer.UsifiedModels
{
    public  class clsInternationalLicense :clsApplication
    {
        public enum enMode {AddNew=1,Update=2} 
        public enMode Mode { get; set; }
       public int InternationalLicenseID{get;set;}
       public int DriverID {get;set;}
       public clsDriver DriverInfo { get; set; }
       public int IssuedUsingLocalLicenseID {get;set;}
       public DateTime IssueDate{get;set;}
       public DateTime ExpirationDate{get;set;}
       public bool IsActive { get; set; }
       
       public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate= DateTime.Now;
            IsActive = false;
            Mode = enMode.AddNew;
        }
        public clsInternationalLicense(int applicationID, int applicantPersonID,
            DateTime applicationDate,
              short applicationStatus, DateTime lastStatusDate,
             double paidFees, int createdByUserID,
             int internationalLicenseID, int driverID, int issuedUsingLocalLicenseID,
            DateTime issueDate, DateTime expirationDate, bool isActive)
        {
            base.ApplicationID = applicationID;
            base.ApplicantPersonID = applicantPersonID;
            base.ApplicationDate = applicationDate;
            base.ApplicationStatus = 0;
            base.LastStatusDate = lastStatusDate;
            base.PaidFees = paidFees;
            base.CreatedByUserID =createdByUserID;

            this.InternationalLicenseID = internationalLicenseID;
            this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            DriverInfo = clsDriver.FindDriverByID(DriverID);
            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            
            this.InternationalLicenseID =
                DataAccessInternationalLicenses.AddNewInternationalLicense
                (
                base.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID
               );
            
            return (InternationalLicenseID > 0);

        }
        private bool _UpdateInternationalLicense()
        {
            return   DataAccessInternationalLicenses.UpdateInternationalLicense
                (
                this.InternationalLicenseID,
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID
               );
         }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())return false ;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateInternationalLicense();
            }
            return false;
        }


        public int GetActiveInternationalLicenseID(int localLicenseID)
        {
            return DataAccessInternationalLicenses.GetActiveInternationalLicenseID(localLicenseID);
        }

        public static clsInternationalLicense FindInternationalLicenseInfoByID(int internationalLicenseID)
        {
            Dictionary<string,object> internationalLicense = null;
            
            if (DataAccessInternationalLicenses.GetInternationalLicenseByID(ref internationalLicense, internationalLicenseID))
            {
                clsApplication application = clsApplication.FindApplicationByID((int)internationalLicense["ApplicationID"]);
                return new clsInternationalLicense
                (
                application.ApplicationID, application.ApplicantPersonID, application.ApplicationDate,
                application.ApplicationStatus, application.LastStatusDate, application.PaidFees, application.CreatedByUserID,
                (int)internationalLicense["InternationalLicenseID"],
                (int)internationalLicense["DriverID"],
                (int)internationalLicense["IssuedUsingLocalLicenseID"],
                (DateTime)internationalLicense["IssueDate"],
                (DateTime)internationalLicense["ExpirationDate"],
                (bool)internationalLicense["IsActive"]
                );
            }
            return null;
        }

        public static DataTable GetInternationalLicensesHistoryByPersonID(int personID)
        {
            return DataAccessInternationalLicenses.GetInternationalLicensesHistoryByPersonID(personID);
        }
        public static DataTable GetInternationalLicenseList()
        {
            return DataAccessInternationalLicenses.GetAllInternationalLicenses();
        }
    }
}

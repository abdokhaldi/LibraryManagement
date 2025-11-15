using DVLD_BussinessLayer.Applications;
using DVLD_BussinessLayer.Detain_Release;
using DVLD_DataAccess.Detain_ReleaseLicense;
using System;
using System.Collections.Generic;
using System.Data;


namespace DVLD_BussinessLayer.Detain_Release
{
    public class clsDetainedReleaseLicense
    {
        enum enMode { AddNew = 1, Update = 2 }
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FinFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
        private enMode Mode { get; set; }

       public clsDetainedReleaseLicense()
        {
           this.DetainID=0;
           this.LicenseID=0;
           this.DetainDate = DateTime.MinValue;
           this.FinFees=0;
           this.CreatedByUserID=0;
           this.IsReleased=false;
           this.ReleaseDate= DateTime.MinValue;
           this.ReleasedByUserID=-1;
           this.ReleaseApplicationID = -1;
           this.Mode = enMode.AddNew;
      }
        private clsDetainedReleaseLicense(int detainID ,int licenseID, DateTime detainDate, float fineFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            this.DetainID = detainID; 
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.FinFees = fineFees;
            this.CreatedByUserID = createdByUserID;
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleasedByUserID = releasedByUserID;
            this.ReleaseApplicationID = releaseApplicationID;
            this.Mode = enMode.Update;
            
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = DataAccessDetain_ReleaseLicense.AddNewDetainLicense(LicenseID,DetainDate, FinFees, CreatedByUserID);
            return (DetainID > 0);
        }
        private bool _UpdateDetainedLicense()
        {
            return  DataAccessDetain_ReleaseLicense.UpdateDetainedLicense(this.DetainID,LicenseID, DetainDate, FinFees, CreatedByUserID);
           
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateDetainedLicense();
            }
            return false;
        }

        public bool ReleaseLicense(int releasedByUserID, int releaseApplicationID)
        {
            return DataAccessDetain_ReleaseLicense.ReleaseDetainedLicense(this.DetainID,
                releasedByUserID,releaseApplicationID);
        }


        public static bool IsDetainedLicense(int licenseID)
        {
            return DataAccessDetain_ReleaseLicense.IsLicenseDetained(licenseID);
        } 

        public static clsDetainedReleaseLicense FindByLicenseID(int licenseID)
        {
            Dictionary<string, object> DetainedLicense = DataAccessDetain_ReleaseLicense.GetByLicenseID(licenseID);
            if (DetainedLicense != null)
            {
                return new clsDetainedReleaseLicense(
                         DetainedLicense["DetainID"] != DBNull.Value ? Convert.ToInt32(DetainedLicense["DetainID"]) : 0,
                         DetainedLicense["LicenseID"] != DBNull.Value ? Convert.ToInt32(DetainedLicense["LicenseID"]) : 0,
                         DetainedLicense["DetainDate"] != DBNull.Value ? Convert.ToDateTime(DetainedLicense["DetainDate"]) : DateTime.MinValue,
                         DetainedLicense["FineFees"] != DBNull.Value ? Convert.ToSingle(DetainedLicense["FineFees"]) : 0f,
                         DetainedLicense["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(DetainedLicense["CreatedByUserID"]) : 0,
                         DetainedLicense["IsReleased"] != DBNull.Value && Convert.ToBoolean(DetainedLicense["IsReleased"]),
                         DetainedLicense["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(DetainedLicense["ReleaseDate"]) : DateTime.MinValue,
                         DetainedLicense["ReleasedByUserID"] != DBNull.Value ? Convert.ToInt32(DetainedLicense["ReleasedByUserID"]) : 0,
                         DetainedLicense["ReleaseApplicationID"] != DBNull.Value ? Convert.ToInt32(DetainedLicense["ReleaseApplicationID"]) : 0
);

            }
            else
            {
                return null;
            }
        }
        

        public static DataTable GetDetainedLicenseList()
        {
            return DataAccessDetain_ReleaseLicense.GetAllDetainedLicenses();
        }

    }
}

using DVLD_DataAccess.LicenseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer.LicensClass
{
    public class clsLicenseClass
    {
        public short LicenseClassID {get;set;}
        public string LicenseClassName { get; set; }
        public string ClassDescription { get; set; }
        public short MinAllowedAge { get; set; }
        public short DefaultValidityLength { get; set; }
        public Decimal ClassFees { get; set; }
        public clsLicenseClass()
        {
            LicenseClassID = 0;
            LicenseClassName = "";
            ClassDescription = "";
            MinAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;
        }
        public static DataTable LicenseClassesList()
        {
            return DataAccessLicenseClass.GetLicenseClasses();
        }
        public static int FindLicenseClassID(string className)
        {
            return DataAccessLicenseClass.GetLicenseClassID(className);
        }
        public static clsLicenseClass FindLicenseClassByID(int classID)
        {
          Dictionary<string,object> licenseClass = DataAccessLicenseClass.GetLicenseClassByID(classID);
            if (licenseClass != null)
            {
                return new clsLicenseClass
                {
                    LicenseClassID = licenseClass.ContainsKey("LicenseClassID")? Convert.ToInt16(licenseClass["LicenseClassID"]):throw new Exception("Invalid key with LicenseClassID"),
                    LicenseClassName = licenseClass.ContainsKey("ClassName") ? licenseClass["ClassName"].ToString(): throw new Exception("Invalid key with LicenseClassID"),
                    ClassDescription = licenseClass.ContainsKey("ClassDescription") ? licenseClass["ClassDescription"].ToString() : throw new Exception("Invalid key with ClassDescription"),
                    MinAllowedAge = licenseClass.ContainsKey("MinimumAllowedAge") ? Convert.ToInt16(licenseClass["MinimumAllowedAge"]) : throw new Exception("Invalid key with MinimumAllowedAge"),
                    DefaultValidityLength = licenseClass.ContainsKey("DefaultValidityLength") ? Convert.ToInt16(licenseClass["DefaultValidityLength"]) : throw new Exception("Invalid key with DefaultValidityLength"),
                    ClassFees = licenseClass.ContainsKey("ClassFees") ? Convert.ToDecimal(licenseClass["ClassFees"]) :  throw new Exception("Invalid key with ClassFees")
                };
            }else
            {
               return null;
            }
        }

    }
}

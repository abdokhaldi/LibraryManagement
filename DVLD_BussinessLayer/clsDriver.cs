using DVLD_DataAccess.Drivers;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_BussinessLayer.Driver
{
   
    public class clsDriver
    {

        public enum enMode {AddNew , Update }
        public enMode Mode { get; set; }
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsPerson PersonInfo { get; set; }
        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.MinValue;
            Mode = enMode.AddNew;
        }
        private clsDriver(int driverID,int personID,int createdByUserID,DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            PersonInfo = clsPerson.FindPerson("PersonID", PersonID);
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
            Mode = enMode.Update;
        }


        public static DataTable GetDriversList()
        {
            return DataAccessDrivers.GetAllDrivers();
        }

        public static clsDriver FindDriverByID(int driverID)
        {
            Dictionary<string, object> driver = null;
            if (DataAccessDrivers.GetDriverByID(driverID,ref driver))
            {
                return new clsDriver(
                    (int)driver["DriverID"],
                    (int)driver["PersonID"],
                    (int)driver["CreatedByUserID"],
                    (DateTime)driver["CreatedDate"]);
             }else
            {
                return null;
            }
        }
        public static clsDriver FindDriverByPersonID(int driverID)
        {
            Dictionary<string, object> driver = null;
            if (DataAccessDrivers.GetDriverByPersonID(driverID, ref driver))
            {
                return new clsDriver(
                    (int)driver["DriverID"],
                    (int)driver["PersonID"],
                    (int)driver["CreatedByUserID"],
                    (DateTime)driver["CreatedDate"]);
            }
            else
            {
                return null;
            }
        }
        
        private bool _AddNewDriver()
        {
            DriverID = DataAccessDrivers.AddNewDriver(this.PersonID,this.CreatedByUserID,this.CreatedDate);
            return (DriverID != -1);
        }
        private bool _UpdateDriver()
        {
            return DataAccessDrivers.UpdateDriver(this.DriverID,this.PersonID,this.CreatedByUserID,this.CreatedDate);
        }
    public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewDriver())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateDriver();
                    }
                }
            return false;
        }
    }
}

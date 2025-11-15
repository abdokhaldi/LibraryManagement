using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DVLD_DataAccess.Drivers
{
    public class DataAccessDrivers
    {
        public static bool GetDriverByID(int driverID, ref Dictionary<string, object> driver)
        {
            
                string query = @"SELECT * FROM Drivers 
                           WHERE DriverID =@driverID";
                Dictionary<string, object> parameters =
                    new Dictionary<string, object>
                    {
                    {"@driverID",driverID}
                    };
            driver = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);

                if (driver != null )
                {
                return true ;
                }
            return false;
            }
        public static bool GetDriverByPersonID(int personID, ref Dictionary<string, object> driver)
        {

            string query = @"SELECT * FROM Drivers 
                           WHERE PersonID =@personID";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    {"@personID",personID}
                };
            driver = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);

            if (driver != null)
            {
                return true;
            }
            return false;
        }

        public static DataTable GetAllDrivers()
        {
            string query = @"SELECT * FROM Drivers_View";
                   
            DataTable dt = (DataTable)SqlDataHelper.ExecuteCommand(query,CommandType.Text,null,SqlDataHelper.enExecuteType.ExecuteDataReaderTable);
            return dt;
        }    
        public static int AddNewDriver(int personID,int createdByUserID,DateTime createdDate)
        {
            string query = @"INSERT INTO Drivers(PersonID,CreatedByUserID,CreatedDate)
                            VALUES(@personID,@createdByUserID,@createdDate);
                            SELECT SCOPE_IDENTITY();";
            Dictionary<string, object> parameters = new Dictionary<string, object> 
            {
                {"@personID",personID },
                {"@createdByUserID",createdByUserID},
                {"@createdDate",createdDate}
            };
            int driverID = -1;
            object result  = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteScalar);
            if (result != null && int.TryParse(result.ToString(),out int _driverID))
            {
                driverID = _driverID;
            }
            return driverID;
        }
        public static bool UpdateDriver(int driverID , int personID, int createdByUserID, DateTime createdDate)
        {
            string query = @"Update Drivers
                            SET 
                              PersonID=@personID,
                              CreatedByUserID=@createdByUserID,
                              CreatedDate=@createdDate
                              WHERE DriverID=@driverID;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@personID",personID},
                {"@createdByUserID",createdByUserID },
                {"@createdDate",createdDate}
            };
            int rowsAffected = (int)SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteNonQuery);
            return rowsAffected > 0;
        }
        }
    }


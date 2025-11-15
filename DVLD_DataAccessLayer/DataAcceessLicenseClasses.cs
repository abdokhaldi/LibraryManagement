
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccess.LicenseClasses
{
    public class DataAccessLicenseClass
    {
        public static DataTable GetLicenseClasses()
        {
           string query = "SELECT * FROM LicenseClasses";
            DataTable dt = (DataTable)SqlDataHelper.ExecuteCommand(query,CommandType.Text,null,SqlDataHelper.enExecuteType.ExecuteDataReaderTable);
            return dt;
        }

        public static int GetLicenseClassID(string className)
        {
            string query = @"SELECT LicenseClassID FROM LicenseClasses
                                   WHERE  ClassName = @className;";
            Dictionary<string, object> parameters =
                 new Dictionary<string, object>()
                 {
                     { "@className",className }
                 };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteScalar");
             return Convert.ToInt32(result);
        }
        public static Dictionary<string,object> GetLicenseClassByID(int classID)
        {
            string query = @"SELECT * FROM LicenseClasses
                                   WHERE  LicenseClassID = @classID;";
            Dictionary<string, object> parameters =
                 new Dictionary<string, object>()
                 {
                     { "@classID",classID }
                 };
            Dictionary<string, object> LicenseClass = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);
            return LicenseClass;
        }

    }
}

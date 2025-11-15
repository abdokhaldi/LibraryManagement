using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DVLD_DataAccess.ApplicationTypes
{
    public class DataAccessApplicationType
    {
        public static DataTable GetApplicationTypes()
        {
            SqlConnection connection = new SqlConnection(SqlDataHelper.connectionString);
            string query = "SELECT * FROM ApplicationTypes";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }
        
        public static bool UpdateApplicationType(int id,string title, double fees)
        {
            int rowsAffected = 0;
            string query = @"Update ApplicationTypes 
                             SET ApplicationTypeTitle=@title,
                                 ApplicationFees=@fees
                             WHERE ApplicationTypeID=@id;";
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>()
            {
                 {"@id",id},
                 {"@title",title},
                 {"@fees",fees}
            };
            rowsAffected = (int)SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,"ExecuteNonQuery");
            return rowsAffected > 0;
        }
        
        public static bool FindApplicationType(int id,ref string title,ref double fees)
        {
            bool isFound = false;
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID=@id";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                    {"@id",id}
                };
            Dictionary<string, object> applicationType =
                (Dictionary<string, object>)SqlDataHelper.ExecuteFindCommand(query,CommandType.Text,parameters);
            if (applicationType != null)
            {
                isFound = true;
                id = applicationType["ApplicationTypeID"] == DBNull.Value ? 0 : (int)applicationType["ApplicationTypeID"];
                title = applicationType["ApplicationTypeTitle"] == DBNull.Value ? "" : (string)applicationType["ApplicationTypeTitle"];
                fees = applicationType["ApplicationFees"] == DBNull.Value ? 0 :  Convert.ToDouble( applicationType["ApplicationFees"]);

            }
            return isFound;
            }
    
    
    
    }
 }

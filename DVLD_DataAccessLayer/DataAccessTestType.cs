using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DVLD_DataAccess.TestTypes
{
    public class DataAccessTestType
    {
        public static DataTable GetTestTypes()
        {
            SqlConnection connection = new SqlConnection(SqlDataHelper.connectionString);
            string query = "SELECT * FROM TestTypes";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }

        public static bool UpdateTestType(int id, string title, string description ,double fees)
        {
            int rowsAffected = 0;
            string query = @"Update TestTypes 
                             SET TestTypeTitle=@title,
                                 TestTypeDescription=@description,
                                 TestTypeFees=@fees
                             WHERE TestTypeID=@id;";
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>()
            {
                 {"@id",id},
                 {"@title",title},
                 {"@fees",fees},
                 {"@description",description }
                 
            };
            rowsAffected = (int)SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteNonQuery");
            return rowsAffected > 0;
        }

        public static bool FindTestType(int id, ref string title,  ref string description, ref double fees)
        {
            bool isFound = false;
            string query = "SELECT * FROM TestTypes WHERE TestTypeID=@id";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                    {"@id",id}
                };
            Dictionary<string, object> testType =
                (Dictionary<string, object>)SqlDataHelper.ExecuteFindCommand(query, CommandType.Text, parameters);
            if (testType != null)
            {
                isFound = true;
                id = testType["TestTypeID"] == DBNull.Value ? 0 : (int)testType["TestTypeID"];
                title = testType["TestTypeTitle"] == DBNull.Value ? "" : (string)testType["TestTypeTitle"];
                description = testType["TestTypeDescription"] == DBNull.Value ? "" : (string)testType["TestTypeDescription"];
                fees = testType["TestTypeFees"] == DBNull.Value ? 0 : Convert.ToDouble(testType["TestTypeFees"]);

            }
            return isFound;
        }



    }
}

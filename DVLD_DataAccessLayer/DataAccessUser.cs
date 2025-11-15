using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.Users
{
    public class DataAccessUser
    {
        public static bool CheckForLogin(string userName, string password)
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM Users WHERE UserName=@userName AND Password=@password";
            Dictionary<string, object> parameters =
                new Dictionary<string, object> (){
                    {"@userName",userName },
                    {"@password",password }
                };
            object result = SqlDataHelper.ExecuteCommand(query,System.Data.CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteScalar);
            count = Convert.ToInt32(result);
            return count > 0;
        }
        public static bool CheckIsUsernameExisting(string userName)
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM Users WHERE UserName=@userName;";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>(){
                    {"@userName",userName },
                   
                };
            object result = SqlDataHelper.ExecuteCommand(query, System.Data.CommandType.Text, parameters, "ExecuteScalar");
            count = Convert.ToInt32(result);
            return count > 0;
        }
        public static bool CheckIsUsernameExisting(int personID)
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM Users WHERE PersonID=@personID;";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>(){
                    {"@personID",personID },

                };
            object result = SqlDataHelper.ExecuteCommand(query, System.Data.CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteScalar);
            count = Convert.ToInt32(result);
            return count > 0;
        }
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(SqlDataHelper.connectionString))
            {
                string query = @"SELECT UserID,People.PersonID, 
                           People.FirstName+ ' '+People.SecondName+' '+ 
                           People.ThirdName+' '+People.LastName AS FullName,
                           UserName,IsActive
                           FROM Users INNER JOIN People
                           ON Users.PersonID=People.PersonID;";
                SqlCommand command = new SqlCommand(query,connection);
                try{
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Load(reader);
                        }

                    }
                        
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
            }

            return dt;
        }
        public static DataTable GetCountries()
        {
            SqlConnection connection = new SqlConnection(SqlDataHelper.connectionString);
            string query = "SELECT * FROM Countries";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }
        public static int AddNewUser(int personID, string userName, string password, bool isActive)
        {
            Dictionary<string, object> parameters;

            string query = @"INSERT INTO Users(PersonID,UserName,Password, IsActive)
                             
                               VALUES(@personID,@userName,@password,@isActive);
                               SELECT SCOPE_IDENTITY();";

            parameters = new Dictionary<string, object>()
                      {
                         
                         {"@personID", personID},
                         {"@userName", userName},
                         {"@password", password},
                         {"@isActive", isActive },
                      };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteScalar");
            return (result != null && int.TryParse(result.ToString(), out int _userID) ? _userID : -1);
        }
        public static int checkIfExisting(string field, string paramValue)
        {
            Dictionary<string, object> parameters;
            string query = "SELECT COUNT(*) FROM People WHERE " + field + " =@paramValue";
            parameters = new Dictionary<string, object>()
            {
                {"@paramValue",paramValue}
            };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteScalar");
            return (result != null && int.TryParse(result.ToString(), out int count) ? count : 0);
        }
        public static bool ChangeUserPassword(int userID,string password)
        {
            string query = @"UPDATE Users
                            SET Password=@password
                            WHERE UserID=@userID;";
            Dictionary<string, object> parameters;

            parameters = new Dictionary<string, object>()
                     {
                         {"@password", password },
                         {"@userID", userID}
                    };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteNonQuery");
            int rowsAffected = 0;
            if (int.TryParse(result.ToString(), out int _rowsAffected))
            {
                rowsAffected = _rowsAffected;
            };
            return (rowsAffected > 0);

        }
        public static bool FindUser(string field, object input, ref int userID, ref int personID, ref string username,ref string password, ref bool isActive )
        {
            bool isFound = false;
            string query = $"SELECT * FROM Users WHERE {field} = @input;";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@input",input}
            };

            Dictionary<string, object> people = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters,SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);
            if (people != null)
            {
                isFound = true;

                userID = people["UserID"] == DBNull.Value ? 0 : (int)people["UserID"];
                personID = people["PersonID"] == DBNull.Value ? 0 : (int)people["PersonID"];
                username = people["UserName"] == DBNull.Value ? "" : (string)people["UserName"];
                password = people["Password"] == DBNull.Value ? "" : (string)people["Password"];
                isActive = people["IsActive"] == DBNull.Value ? false : (bool)people["IsActive"];
            }
            
            return isFound;
        }
        public static bool DeleteUser(int userID)
        {
            object result;
            string query = @"DELETE FROM Users WHERE UserID=@userID";
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>()
            {
                {"@userID",userID }
            };
            result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteNonQuery");
            int rowsAffected = 0;
            if (int.TryParse(result.ToString(), out int _rowsAffected))
            {
                rowsAffected = _rowsAffected;
            }
            return (rowsAffected > 0);
        }
        public static bool UpdateUser(int userID,int personID,string username, bool isActive)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Users 
                             SET PersonID=@personID,
                                 UserName=@username,
                                 IsActive=@isActive
                             WHERE UserID=@userID;";
          Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@userID",userID},
                {"@personID",personID},
                {"@username",username},
                {"@isActive",isActive}
            };

            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters,"ExecuteNonQuery");

            if (int.TryParse(result.ToString(), out int _rowsAffected))
            {
                rowsAffected = _rowsAffected;
            }
            return (rowsAffected > 0);
        }


    }
}

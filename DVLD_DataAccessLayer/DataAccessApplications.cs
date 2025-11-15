using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccess.Applications
{
    public class DataAccessApplications
    {
        public static int AddNewApplication(int applicantPersonID, DateTime applicationDate, short applicationTypeID, short applicationStatus,
        DateTime lastStatusDate, double paidFees, int createdByUserID)
        {
              string query = @"INSERT INTO Applications (
                             ApplicantPersonID, 
                             ApplicationDate, 
                             ApplicationTypeID, 
                             ApplicationStatus, 
                             LastStatusDate, 
                             PaidFees, 
                             CreatedByUserID)
                            VALUES (
                             @applicantPersonID, 
                             @applicationDate, 
                             @applicationTypeID, 
                             @applicationStatus, 
                             @lastStatusDate, 
                             @paidFees, 
                             @createdByUserID);
                            SELECT SCOPE_IDENTITY();"; //Get Inserted ID

                Dictionary<string, object> parameters =
                 new Dictionary<string, object> {

                        {"@applicantPersonID", applicantPersonID},
                        {"@applicationDate", applicationDate},
                        {"@applicationTypeID", applicationTypeID },
                        {"@applicationStatus", applicationStatus},
                        {"@lastStatusDate", lastStatusDate },
                        {"@paidFees", paidFees},
                        {"@createdByUserID", createdByUserID},
                 };

                var applicationID = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteScalar);
                
            if (int.TryParse(applicationID.ToString(), out int appID))
                {
                return appID;
                }
            
                return -1;
            
            }

        public static bool UpdateApplication(int applicationID, int applicantPersonID, DateTime applicationDate,
             short applicationTypeID,short applicationStatus,double paidFees , DateTime lastStatusDate,int createdByUserID
      )
        {
           
        string query = @"UPDATE Applications 
             SET 
                ApplicantPersonID = @applicantPersonID,
                ApplicationDate = @applicationDate,
                ApplicationTypeID = @applicationTypeID,
                ApplicationStatus = @applicationStatus,
                LastStatusDate = @lastStatusDate,
                PaidFees = @paidFees,
                CreatedByUserID = @createdByUserID 
              WHERE ApplicationID=@applicationID;";

            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                        {"@applicationID", applicationID},
                        {"@applicantPersonID", applicantPersonID},
                        {"@applicationDate", applicationDate},
                        {"@applicationTypeID", applicationTypeID },
                        {"@applicationStatus", applicationStatus},
                        {"@lastStatusDate", lastStatusDate },
                        {"@paidFees", paidFees},
                        {"@createdByUserID", createdByUserID},
                };
            int rowsAffected = 0;
           object  result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteNonQuery);
            if (int.TryParse(result.ToString(),out int _result))
            {
                rowsAffected = _result;
            }
            return (rowsAffected > 0);
        }

        public static Dictionary<string,object> GetApplicationByID(int applicationID)
        {
            string query = @"SELECT * FROM Applications WHERE ApplicationID=@applicationID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@applicationID",applicationID }
            };
            Dictionary<string, object> applicationInfo = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query,CommandType.Text, parameters,SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);
            return applicationInfo;
        }



        // waiting
        public static int GetApplicationID(int ldlAppID)
        {

            string query = $@"SELECT ApplicationID 
                             FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID=@ldlAppID;";


            Dictionary<string, object> parameters =
             new Dictionary<string, object>()
             {
                      { "@ldlAppID",ldlAppID},
                     
             };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteScalar");
            return Convert.ToInt32(result);
        }

        // waiting
        public static int _GetApplicationStatus(int applicationID)
        {
            string query = @"SELECT ApplicationStatus
                      FROM Applications
                     WHERE ApplicationID=@applicationID";
            
            Dictionary<string, object> parameters
                = new Dictionary<string, object>()
                {
                    {"@applicationID",applicationID }
                };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteScalar");
             return Convert.ToInt32(result);
        }

        // waiting
        public static bool _DeleteApplication(int applicationID)
        {

            bool isDeleted = false;
            

            using (var connection = new SqlConnection(SqlDataHelper.connectionString))
            {

                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteLocalDrivingLicenseAppliction =
                            @"DELETE FROM LocalDrivingLicenseApplications WHERE ApplicationID=@applicationID";
                        using (var command = new SqlCommand(deleteLocalDrivingLicenseAppliction, connection, transaction))
                        {
                            command.Parameters.AddWithValue(@"applicationID", applicationID);
                            command.ExecuteNonQuery();
                        }

                        string deleteApplication =
                            @"DELETE FROM Applications WHERE ApplicationID=@applicationID";
                        using (var command = new SqlCommand(deleteApplication, connection, transaction))
                        {
                            command.Parameters.AddWithValue(@"applicationID", applicationID);
                            command.ExecuteNonQuery();
                        }
                        
                        transaction.Commit();
                        isDeleted = true;
                    }

                    catch (Exception ex)
                    {
                        isDeleted = false;
                    }
                }

            }
            return isDeleted;
        }

        // waiting
        public static int UpdateApplicationStatus(int ldlApplicationID, short applicationStatus)
        {
            string query = @"Update Applications 
                             SET ApplicationStatus = @applicationStatus, 
                             LastStatusDate = @lastStatusDate
                             WHERE  ApplicationID = 
                                     (SELECT LocalDrivingLicenseApplications.ApplicationID FROM LocalDrivingLicenseApplications 
                               INNER JOIN Applications
                               ON LocalDrivingLicenseApplications.ApplicationID= Applications.ApplicationID
                              WHERE LocalDrivingLicenseApplicationID=@ldlApplicationID);";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                    { "@ldlApplicationID", ldlApplicationID },
                    { "@applicationStatus", applicationStatus },
                    { "@lastStatusDate", DateTime.Now },
                };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteNonQuery");
            int rowsAffected = 0;
            if (int.TryParse(result.ToString(), out int _rowsAffected))
            {
                rowsAffected = _rowsAffected;
            }
            else
            {
                rowsAffected = 0;
            }
            return rowsAffected;
        }
        
        public static int DeleteApplication(int applicationID)
        {
            int rowsAffected = 0;
            string query = @"DELETE FROM Applications
                            WHERE ApplicationID=@applicationID";

            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    {"@applicationID",applicationID}
                };
            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteNonQuery);
            if (int.TryParse(result.ToString(),out int _result) )
            {
                rowsAffected = _result;
            }
            return rowsAffected;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.LocalDrivingLicenseApplications
{
    public class DataAccessTestAppointments
    {
        
        public static int AddNewTestAppointment(int testTypeID,int localDrivingLicenseID,DateTime? appointmentDate,
            decimal paidFees,int createdByUserID,bool isLocked)
        {
            string query = @"INSERT INTO TestAppointments(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked)
                            VALUES(@testTypeID,@localDrivingLicenseID,@appointmentDate,@paidFees,@createdByUserID,@isLocked);
                             SELECT SCOPE_IDENTITY();";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    { "@testTypeID",testTypeID },
                    { "@localDrivingLicenseID",localDrivingLicenseID},
                    { "@appointmentDate",appointmentDate},
                    { "@paidFees",paidFees},
                    { "@createdByUserID",createdByUserID},
                    { "@isLocked",isLocked}
                };
            object result = SqlDataHelper.ExecuteCommand(query,System.Data.CommandType.Text, parameters,"ExecuteScalar");
            int appointmentID = 0;
            if (result != null && int.TryParse(result.ToString(), out int _appointmentID))
            {
                 appointmentID = _appointmentID;
            }
            else
            {
                appointmentID = 0; ;
            }
            return appointmentID;
        }

        public static int AddNewTestAppointmentWithApplication(int applicantPersonID, DateTime? applicationDate, int applicationTypeID, int applicationStatus,
        DateTime? lastStatusDate, double appFees, int createdByUserID, int testTypeID, int localDrivingLicenseID, DateTime? appointmentDate,
            decimal paidFees, bool isLocked)
        {
            int applicationID,testAppointmentID;
            using (var connection = new SqlConnection(SqlDataHelper.connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query1 = @"INSERT INTO Applications (
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

                       
                        Dictionary<string, object> parameters1 = new Dictionary<string, object>
                        {
                           { "@applicantPersonID", applicantPersonID},
                           { "@applicationDate", applicationDate},
                           { "@applicationTypeID", applicationTypeID},
                           { "@applicationStatus", applicationStatus},
                           { "@lastStatusDate", lastStatusDate},
                           { "@paidFees", paidFees},
                           { "@createdByUserID", createdByUserID },

                        };
                        
                            applicationID = SqlDataHelper.ExecuteCommandForTransaction(query1,connection,CommandType.Text,transaction,parameters1,SqlDataHelper.enExecuteType.ExecuteScalar);

                   string query2 = @"INSERT INTO TestAppointments(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
                               VALUES(@testTypeID,@localDrivingLicenseID,@appointmentDate,@paidFees,@createdByUserID,@isLocked,@applicationID);
                                SELECT SCOPE_IDENTITY();";
                   Dictionary<string, object> parameters2 =
                      new Dictionary<string, object>
                            {
                            { "@testTypeID",testTypeID },
                            { "@localDrivingLicenseID",localDrivingLicenseID},
                            { "@appointmentDate",appointmentDate},
                            { "@paidFees",paidFees},
                            { "@createdByUserID",createdByUserID},
                            { "@isLocked",isLocked},
                            { "@applicationID",applicationID}
                            };

                        testAppointmentID = SqlDataHelper.ExecuteCommandForTransaction(query2, connection, CommandType.Text, transaction, parameters2, SqlDataHelper.enExecuteType.ExecuteScalar);
                      transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
             }
            return testAppointmentID;
        }


        public static bool UpdateTestAppointment(int testAppID,DateTime? appointmentDate)
        {
            string query = @"UPDATE TestAppointments
                             SET AppointmentDate=@appointmentDate
                             WHERE TestAppointmentID=@testAppID";
            Dictionary<string, object> parameters =
                new Dictionary<string, object> 
                {
                    { "@testAppID",testAppID},
                    { "@appointmentDate",appointmentDate }
                };
            int rowsAffected = (int)SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,"ExecuteNonQuery");
            return (rowsAffected>0);
       }
       
        public static Dictionary<string,object> GetTestAppointmentByID(int tstAppID)
        {
            string query = @"SELECT * FROM TestAppointments
                           WHERE TestAppointmentID=@tstAppID";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    {"@tstAppID", tstAppID}
                };
            Dictionary<string, object> tstAppointment =
                (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,"ExecuteReaderSingleRow");
            return tstAppointment;
        }

        public static DataTable GetAppointmentByLDLAppID(int ldlAppID, short testTypeID)
        {
           string query = @"SELECT TestAppointmentID ,TestTypeID ,AppointmentDate , TestAppointments.PaidFees,IsLocked 
                   FROM TestAppointments INNER JOIN LocalDrivingLicenseApplications
                   ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                   INNER JOIN Applications 
                   ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                   WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @ldlAppID
                   AND TestAppointments.TestTypeID=@testTypeID;";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    { "@testTypeID",testTypeID},
                    { "@ldlAppID", ldlAppID}
                };
            DataTable testAppointments;
            testAppointments = (DataTable) SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters, SqlDataHelper.enExecuteType.ExecuteDataReaderTable);
            
                return testAppointments;
            
         }
       
        // to know number of locked or unlocked test appointments
        public static short GetNumberOfTestAppointmentStates(int ldlAppID, bool isLocked)
        {
            string query = @"SELECT COUNT(*)
                             FROM TestAppointments
                             WHERE LocalDrivingLicenseApplicationID=@ldlAppID AND IsLocked=@isLocked";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    { "@ldlAppID",ldlAppID},
                    { "@isLocked",isLocked}
                };
            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,"ExecuteScalar");
            return Convert.ToInt16(result);
        }

        public static bool LockAppointment(int testAppID)
        {
            string query = @"UPDATE TestAppointments
                             SET IsLocked=1
                             WHERE TestAppointmentID=@testAppID";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    { "@testAppID",testAppID},
                    
                };
            int rowsAffected = 0;
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteNonQuery");
            if (int.TryParse(result.ToString(),out int n))
            {
                rowsAffected = n;
            }
            return (rowsAffected>0);
        }

        

    }
}

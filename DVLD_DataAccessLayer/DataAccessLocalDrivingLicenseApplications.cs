using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DVLD_DataAccess.Applications
{
    public class DataAccessLocalDrivingLicenseApplications
    {

        public static DataTable GetLDLApplacations()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connecton = new SqlConnection(SqlDataHelper.connectionString))
            {
                string query = @"SELECT * FROM LocalDrivingLicenseApplications_View";

                  
                       
                SqlCommand command = new SqlCommand(query, connecton);
                try
                {
                    connecton.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
            }
            return dt;
        }
        // check if application already existing with some classLicens and nationalNo and status = new
        public static int GetActiveApplicationIDForLicenseClass(int applicantPersonID,short licenseClassID, short applicationTypeID)
        {
            int ActiveApplicationID = -1;
            string query = $@"SELECT ActiveApplication=Applications.ApplicationID FROM Applications 
                            INNER JOIN LocalDrivingLicenseApplications
							ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            WHERE ApplicantPersonID = @applicantPersonID 
                            AND ApplicationTypeID=@applicationTypeID
                            AND LocalDrivingLicenseApplications.LicenseClassID = @licenseClassID
                            AND ApplicationStatus=1;";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                    {"@applicantPersonID",applicantPersonID },
                    {"@applicationTypeID",applicationTypeID },
                    {"@licenseClassID",licenseClassID}
                };
            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteScalar);
            if (result != null && int.TryParse(result.ToString(), out int lblAppID))
            {
                ActiveApplicationID = lblAppID;
            }
            return ActiveApplicationID;
        }
     
        public static bool GetLDLApplication_ViewByID(int ldlAppID,ref string className, ref int passedTestCount)
        {
            bool isFound=false;
            string query = @"SELECT  ClassName , PassedTestCount
                             FROM LocalDrivingLicenseApplications_View
                             WHERE LocalDrivingLicenseApplicationID=@ldlAppID";
            Dictionary<string, object> parameters =
               new Dictionary<string, object>
               {
                   {"@ldlAppID",ldlAppID }
               };

            Dictionary<string, object> ldlApplication = (Dictionary<string, object>) SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, "ExecuteReaderSingleRow");
            
              if (ldlApplication != null)
                {
                    isFound = true;
                    className = ldlApplication["ClassName"] as string;
                    passedTestCount = Convert.ToInt16(ldlApplication["PassedTestCount"]);
                }
             return isFound;
        }


        // current work is bellow
        public static bool GetLocalDrivingLicenseApplicationByID(int ldlAppID ,ref int licenseClassID, ref int applicationID)
        {
            bool isFound = false;
            string query = @"SELECT  * FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID=@ldlAppID";
            Dictionary<string, object> parameters =
               new Dictionary<string, object>
               {
                   {"@ldlAppID",ldlAppID }
               };

            Dictionary<string, object> ldlApplication = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);

            if (ldlApplication != null)
            {
                isFound = true;
                applicationID = (int)ldlApplication["ApplicationID"];
                licenseClassID = (int)ldlApplication["LicenseClassID"];
                
            }
            return isFound;
        }
        
        public static int AddNewLocalDrivingLicenseApplication(
            int applicationID, int licenseClassID)
        {
            string query = @"INSERT INTO LocalDrivingLicenseApplications(ApplicationID, LicenseClassID)
                       VALUES(@applicationID,@licenseClassID);                         
                       SELECT SCOPE_IDENTITY();";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                    {"@applicationID",applicationID },
                    {"@licenseClassID",licenseClassID }
                };
            int ID = -1;
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteScalar);

            if (result != null && int.TryParse(result.ToString(), out int _result))
            {
                ID = _result;
            }
            return ID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(
           int ID, int applicationID, int licenseClassID)
        {
            string query = @"Update LocalDrivingLicenseApplications
               SET 
                 ApplicationID = @applicationID,
                 LicenseClassID = @licenseClassID                        
               WHERE LocalDrivingLicenseApplicationID= @ID;";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                    {"@ID",ID},
                    {"@applicationID",applicationID },
                    {"@licenseClassID",licenseClassID }
                };
            int rowsAffected = 0;
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteNonQuery);
            if (result != null && int.TryParse(result.ToString(),out int _result))
            {
                rowsAffected = _result;
            }
            return rowsAffected >0; 
        }
        public static int DeleteLocalDrivingLicenseApplication(int ldlApplicationID)
        {
            int rowsAffected = 0;
            string query = @"DELETE FROM LocalDrivingLicenseApplications
                            WHERE LocalDrivingLicenseApplicationID=@ldlApplicationID";

            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    {"@ldlApplicationID",ldlApplicationID}
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

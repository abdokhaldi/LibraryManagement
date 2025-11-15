using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Web;


namespace DVLD_DataAccess.InternationalLicenses
{
    public class DataAccessInternationalLicenses
    {
        public static int AddNewInternationalLicense
            (
            int applicationID,
            int driverID,
            int issuedUsingLocalLicenseID,
            DateTime issueDate,
            DateTime expirationDate,
            bool isActive,
            int createdByUserID
            )
        {
            int internationalLicenseID = -1;
            string query = @"INSERT INTO 
                     InternationalLicenses(ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID)
                     VALUES(@applicationID,@driverID,@issuedUsingLocalLicenseID,@issueDate,@expirationDate,@isActive,@createdByUserID);
                     SELECT SCOPE_IDENTITY()";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                       {
                            {"@applicationID", applicationID},
                            {"@driverID", driverID},
                            {"@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID},
                            {"@issueDate", issueDate},
                            {"@expirationDate", expirationDate},
                            {"@isActive", isActive},
                            {"@createdByUserID", createdByUserID},
                        };
            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteScalar);
            if (int.TryParse(result.ToString(),out int ID))
            {
                internationalLicenseID = ID;
            }
            return internationalLicenseID;
        }

        public static bool UpdateInternationalLicense
           (
           int internationalLicenseID,
           int applicationID,
           int driverID,
           int issuedUsingLocalLicenseID,
           DateTime issueDate,
           DateTime expirationDate,
           bool isActive,
           int createdByUserID
           )
        {

            string query = @"UPDATE InternationalLicenses 
                                    ApplicationID= @applicationID,
                                    DriverID= @driverID,
                                    IssuedUsingLocalLicenseID= @issuedUsingLocalLicenseID,
                                    IssueDate= @issueDate,
                                    ExpirationDate=@expirationDate,
                                    IsActive= @isActive,
                                    CreatedByUserID=@createdByUserID
                              WHERE InternationalLicenseID=@internationalLicenseID"; 
                    
                    

            Dictionary<string, object> parameters = new Dictionary<string, object>
                       {
                            {"@internationalLicenseID",internationalLicenseID},
                            {"@applicationID", applicationID},
                            {"@driverID", driverID},
                            {"@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID},
                            {"@issueDate", issueDate},
                            {"@expirationDate", expirationDate},
                            {"@isActive", isActive},
                            {"@createdByUserID", createdByUserID},
                        };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteNonQuery);
            if (int.TryParse(result.ToString(), out int ID))
            {
                return (ID >0);
            }
            return false ;
        }


        public static int GetActiveInternationalLicenseID(int localLicenseID)
        {
            int isFound = -1;
            string query = @"SELECT InternationalLicenseID FROM InternationalLicenses WHERE IssuedUsingLocalLicenseID=@localLicenseID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@localLicenseID", localLicenseID}
            };

            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteScalar);
            if (result != null)
            {
               return Convert.ToInt32(result) ;
            }
            return -1;
        }

        public static bool GetInternationalLicenseByID(ref Dictionary<string, object> internationalLicense,int internationalLicenseID)
        {
            string query = @"SELECT * FROM InternationalLicenses 
                            WHERE InternationalLicenseID=@internationalLicenseID;";

            Dictionary<string, object> parameters =
              new Dictionary<string, object>
              {
                  {"@internationalLicenseID", internationalLicenseID}
              };
            internationalLicense = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query,System.Data.CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);
            if (internationalLicense != null)
            {
                return true;
            }
            return false;
        }

        public static DataTable GetInternationalLicensesHistoryByPersonID(int personID)
        {
            string query = @"SELECT InternationalLicenseID AS Int_LicenseID,InternationalLicenses.ApplicationID,InternationalLicenses.IssuedUsingLocalLicenseID AS L_LicenseID, IssueDate,ExpirationDate,IsActive 
                FROM InternationalLicenses 
                INNER JOIN Drivers 
                   ON InternationalLicenses.DriverID = Drivers.DriverID 
                WHERE Drivers.PersonID=@personID;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@personID",personID}
            };
            DataTable dt = (DataTable)SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteDataReaderTable);
            return dt;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            string query = "SELECT * FROM InternationalLicenses;";
            DataTable dt = (DataTable)SqlDataHelper.ExecuteCommand(query, CommandType.Text,null,SqlDataHelper.enExecuteType.ExecuteDataReaderTable);
            return dt;
        }

    }
}

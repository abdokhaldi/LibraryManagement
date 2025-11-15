using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess.LocalDrivingLicenseApplications
{
    public class DataAccessLicenses
    {
        

    public static int IssueDriverLicense
             (
                int applicationID,int driverID ,int licenseClassID,
                DateTime issueDate, DateTime expirationDate,
                string notes, double paidFees, bool isActive,
                short issueReason, int createdByUserID
             )
        {
            try
            {
                string query = @"INSERT INTO 
                   Licenses (ApplicationID,DriverID,LicenseClass,
                             IssueDate,ExpirationDate,Notes,PaidFees,IsActive,
                             IssueReason,CreatedByUserID)
                   VALUES(@applicationID,@driverID,@licenseClassID,
                          @issueDate,@expirationDate,@notes,@paidFees,
                          @isActive,@issueReason,@createdByUserID);
                   SELECT SCOPE_IDENTITY();";

                Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                     { "@applicationID", applicationID},
                     { "@licenseClassID", licenseClassID},
                     { "@driverID", driverID},
                     { "@issueDate", issueDate},
                     { "@expirationDate", expirationDate},
                     { "@notes", notes},
                     { "@paidFees", paidFees},
                     { "@isActive", isActive},
                     { "@issueReason", issueReason},
                     { "@createdByUserID", createdByUserID}
                   };

                object result = SqlDataHelper.ExecuteCommand(query, System.Data.CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteScalar);
                int licenseID = 0;
                if (int.TryParse(result.ToString(), out int _licenseID))
                {
                    licenseID = _licenseID ;
                }
                return licenseID;
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}", ex);
            }  
               
        }

    public static short GetCountLicenseBelongsToLDLApp_ByLDLAppID(int ldlApp)
        {
            string query = @"SELECT COUNT(*) FROM Licenses
                             INNER JOIN Applications 
                             ON Licenses.ApplicationID = Applications.ApplicationID
                             INNER JOIN LocalDrivingLicenseApplications
                             ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                             WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @ldlApp;";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    { "@ldlApp",ldlApp}
                };
            object resultCount = SqlDataHelper.ExecuteCommand(query,CommandType.Text, parameters,SqlDataHelper.enExecuteType.ExecuteScalar);
            return Convert.ToInt16(resultCount);
        }
    public static short GetCountLicenseByLicenseID(int licenseID)
        {
            string query = @"SELECT COUNT(*) FROM Licenses
                             WHERE LicenseID = @licenseID;";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    { "@licenseID",licenseID}
                };
            object resultCount = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteScalar);
            return Convert.ToInt16(resultCount);
        }
    public static DataTable GetLicensesHistoryByPersonID(int personID)
        {
            string query = @"SELECT Licenses.LicenseID,Licenses.ApplicationID,Licenses.DriverID,LicenseClasses.ClassName,Licenses.IssueDate,Licenses.ExpirationDate,Licenses.IsActive,Licenses.CreatedByUserID FROM Licenses 
                             INNER JOIN Drivers
                             ON Licenses.DriverID=Drivers.DriverID
                             INNER JOIN LicenseClasses
                             ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                             WHERE Drivers.PersonID=@personID;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@personID",personID}
            };
            DataTable dt = (DataTable)SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteDataReaderTable);
            return dt;
        }
    public static bool GetLicenseInfoByID(int licenseID,ref Dictionary<string, object> license)
        {
            bool isFound = false;
            string query = @"SELECT * FROM Licenses 
                              WHERE LicenseID=@licenseID;";
            Dictionary<string, object> parameters =
                   new Dictionary<string, object>
                   {
                       { "@licenseID",licenseID}
                   };
             license = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);
            if (license != null)
            {
                isFound = true;
            }
            return isFound ;
        }
    public static int GetActiveLicenseID(int personID,int licenseClassID)
        {
            int licenseID = -1;
            string query = @"SELECT Licenses.LicenseID  FROM Licenses 
                            INNER JOIN Drivers 
                            ON Licenses.DriverID=Drivers.DriverID
                            WHERE Drivers.PersonID =@driverID
                            AND Licenses.LicenseClass=@licenseClassID
                            AND IsActive=1;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
             {
                { "@driverID", personID },
                { "@licenseClassID",licenseClassID}
            };
            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteScalar);
            if (result!=null && int.TryParse(result.ToString(),out int ID))
            {
                licenseID = ID;
            }
            return licenseID;
        }
    public static bool DesactiveLicense(int licenseID)
        {

            string query = @"UPDATE Licenses SET IsActive=0 WHERE LicenseID=@licenseID;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
             {

                { "@licenseID",licenseID}
            };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteNonQuery);
            if (result != null && int.TryParse(result.ToString(), out int rowsAfected))
            {
                return (rowsAfected > 0);
            }
            throw new Exception("The result returned From Database as a row affected is can't convert to number");
        }
    public static bool IsPersonHasLicenseClass(int personID, int licenseClassID)
        {
            string query = @"SELECT IsFound=COUNT(*) FROM Licenses
                           INNER JOIN Drivers ON Licenses.DriverID=Drivers.DriverID
                           WHERE Drivers.PersonID=@driverID 
                           AND Licenses.LicenseClass=@licenseClassID;";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    {"@driverID" ,personID},
                    {"@licenseClassID",licenseClassID }
                };
            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteScalar);
            if (result != null && int.TryParse(result.ToString(),out int founded))
            {
                return founded > 0;
            }
            Console.WriteLine("Warning: Unexpected result in IsPersonHasLicenseClass query. Returning false.");
            return false;
        }



    }
}

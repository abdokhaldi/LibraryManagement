using System;
using System.Collections.Generic;
using System.Data;



namespace DVLD_DataAccess.Detain_ReleaseLicense
{
    public class DataAccessDetain_ReleaseLicense
    {
        public static bool IsLicenseDetained(int licenseID)
        {
            bool isDetained = false;
            string query = @"SELECT IsDetained=1 FROM DetainedLicenses
                             WHERE LicenseID=@licenseID 
                             AND IsReleased=0;";
            Dictionary<string, object> parameter = new Dictionary<string, object>
            {
                {"@licenseID",licenseID }
            };
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameter, SqlDataHelper.enExecuteType.ExecuteScalar);
            
            if (result != null)
            {
                isDetained = Convert.ToBoolean(result);
            }
            return isDetained;
        }

        public static int AddNewDetainLicense(int licenseID, DateTime detainDate, float fineFees, int createdByUserID)
        {
            string query = @"INSERT INTO DetainedLicenses (LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased)
                         VALUES(@licenseID,@detainDate,@fineFees,@createdByUserID,0);
                         SELECT SCOPE_IDENTITY();";
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>
            {
                {"@licenseID", licenseID },
                {"@detainDate ",detainDate},
                {"@fineFees ",fineFees}, 
                {"@createdByUserID ",createdByUserID },
                
            };
            object detainedLicense = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteScalar);
            return Convert.ToInt32(detainedLicense);
        }
        public static bool UpdateDetainedLicense(int detainID,int licenseID, DateTime detainDate, float fineFees, int createdByUserID)
        {
            string query = @"UPDATE DetainedLicenses
                         SET 
                             LicenseID=@licenseID,
                             DetainDate=@detainDate,
                             FineFees=@fineFees,
                             CreatedByUserID=@createdByUserID,
                       WHERE DetainID=@detainID;";
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>
            {
                {"@licenseID", licenseID },
                {"@detainDate ",detainDate},
                {"@fineFees ",fineFees},
                {"@createdByUserID ",createdByUserID },
                
            };
            object rowsAffected = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteNonQuery);
            return (Convert.ToInt32(rowsAffected) >0);
        }

        
       // _______________________

        public static Dictionary<string,object> GetByLicenseID(int licenseID)
        {
            string query = @"SELECT * FROM DetainedLicenses
                             WHERE LicenseID=@licenseID AND IsReleased=0;";
            Dictionary<string, object> parameter = new Dictionary<string, object>
            {
                { "@licenseID",licenseID }
            };
            Dictionary<string, object> detainedLicense = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameter,SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);
            return detainedLicense;
        }

        public static bool ReleaseDetainedLicense(int detainID,int releasedByUserID,int releaseApplicationID)
        {
            
                  string query1 = @"UPDATE DetainedLicenses
                        SET IsReleased=1,
                            ReleaseDate=@releaseDate,
                            ReleasedByUserID=@releasedByUserID,
                            ReleaseApplicationID=@releaseApplicationID
                            WHERE DetainID=@detainID;";

                  Dictionary<string, object> parameters = new Dictionary<string, object>
                       { {"@detainID",detainID },
                         {"@releasedByUserID", releasedByUserID},
                         {"@releaseApplicationID",releaseApplicationID },
                         {"@releaseDate", DateTime.Now},
                       };

                       object rowsAffected = SqlDataHelper.ExecuteCommand(query1,CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteNonQuery);
                      return (Convert.ToInt32(rowsAffected) >0);
               }
            
        public static DataTable GetAllDetainedLicenses()
        {
            string query = @"select DetainedLicenses.DetainID,DetainedLicenses.LicenseID, 
                    DetainedLicenses.DetainDate,DetainedLicenses.IsReleased,
                    DetainedLicenses.FineFees,DetainedLicenses.ReleaseDate,
                    P1.NationalNo , P1.FirstName+' '+P1.SecondName+' '+P1.ThirdName+' '+P1.LastName AS FullName,
                    DetainedLicenses.ReleaseApplicationID
                    FROM DetainedLicenses 
                     JOIN Licenses AS L
                    ON DetainedLicenses.LicenseID = L.LicenseID
                     JOIN Applications AS A1
                    ON L.ApplicationID = A1.ApplicationID
                     JOIN People AS P1
                    ON A1.ApplicantPersonID = P1.PersonID
                         ;";
            DataTable detainedLicensesList =
                   (DataTable)SqlDataHelper.ExecuteCommand(query,CommandType.Text,null,SqlDataHelper.enExecuteType.ExecuteDataReaderTable);
            return detainedLicensesList;
        }

    }
}

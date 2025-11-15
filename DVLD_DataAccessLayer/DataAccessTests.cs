using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DVLD_DataAccess.LocalDrivingLicenseApplications
{
    public class DataAccessTests
    {
        public static int AddNewTest(int testAppID,bool testResult,string notes, int createdByUserID )
        {
            string query = @"INSERT INTO Tests(TestAppointmentID,TestResult,Notes,CreatedByUserID)
                            VALUES(@testAppID,@testResult,@notes,@createdByUserID);
                            SELECT SCOPE_IDENTITY();";
            Dictionary<string, object> parameters =
                new Dictionary<string, object>
                {
                    {"@testAppID", testAppID},
                    {"@testResult", testResult},
                    {"@notes", notes},
                    {"@createdByUserID", createdByUserID}
                };
            
           object result  = SqlDataHelper.ExecuteCommand(query,System.Data.CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteNonQuery);
            if (int.TryParse(result.ToString(),out int _testID))
            {
                return _testID;
            }
            else
            {
            return 0;
            }
        }

        // CountTestResultsForTestType() : counts passed or fail tests for each testType  
        public static short CountTestResultsForTestType(int ldlAppID,short isPass, short testTypeID)
        {
            string query = @"Select Count(*) from tests 
                             inner join TestAppointments 
                             on tests.TestAppointmentID = TestAppointments.TestAppointmentID
                             where tests.TestResult =@isPass 
                             and TestAppointments.LocalDrivingLicenseApplicationID=@ldlAppID
                             and TestAppointments.TestTypeID=@testTypeID;";
           Dictionary<string,object> parameters = 
                new Dictionary<string,object> {

                  { "@ldlAppID", ldlAppID},
                  { "@isPass",isPass },
                  {"@testTypeID",testTypeID }
                  };

            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteScalar);
            // short count = -1;
            if (result != null && short.TryParse(result.ToString(), out short _count))
            {
                return _count;
            }
            else
            {
                throw new Exception($"the resul of CountTestResultsForTestType is returned result as {result.ToString()}");
            }
            }

        // CountAllPassedTestsForCurrentLDLApplication() : counts all passed tests for for this current Local driving license application  
        public static short CountAllPassedTestsForCurrentLDLApplication(int ldlAppID,short isPass)
        {
            string query = @"Select Count(*) from tests 
                             inner join TestAppointments 
                             on tests.TestAppointmentID=TestAppointments.TestAppointmentID
                             where tests.TestResult=@isPass 
                             and TestAppointments.LocalDrivingLicenseApplicationID=@ldlAppID ;";
            Dictionary<string, object> parameters =
                 new Dictionary<string, object> {

                  { "@ldlAppID", ldlAppID},
                     {"@isPass",isPass}
                   };

            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteScalar);
            short count = -1;
            if (result != null && short.TryParse(result.ToString(), out short _count))
            {
                count =  _count;
            }
            return count;
        }

    }
}

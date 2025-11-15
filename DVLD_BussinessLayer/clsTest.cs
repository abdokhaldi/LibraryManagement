using DVLD_DataAccess.LocalDrivingLicenseApplications;


namespace DVLD_BussinessLayer.LocalDrivingLicenseApplications
{
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            this.TestID = 0;
            this.TestAppID = 0;
            this.TestResult = false;
            this.Notes = string.Empty;
            this.CreatedByUserID = 0;
        }

       public bool AddNewTest()
        {
            this.TestID = DataAccessTests.AddNewTest(this.TestAppID,this.TestResult,this.Notes,this.CreatedByUserID);
            return (this.TestID != 0);
        }

        public static short CountTestResultsForCurrentTestType(int ldlAppID,short isPass, short testType)
        {
            return DataAccessTests.CountTestResultsForTestType(ldlAppID, isPass ,testType);
        }

        public static short CountAllPassedTestsForCurrentLDLApplication(int ldlAppID)
        {
            return DataAccessTests.CountAllPassedTestsForCurrentLDLApplication(ldlAppID,1);
        }
    }
}

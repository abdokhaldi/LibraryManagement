using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.Countries
{
    public class DataAccessCountry
    {
        public static bool GetCountry(int id,ref int countryID,ref string countryName)
        {
            bool isFound = false;
            string query = "SELECT * FROM Countries WHERE CountryID=@id";
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>()
            {
                {"@id",id}
            };
            Dictionary<string, object> country;
            country = (Dictionary<string, object>)SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);
            
            if (country != null)
            {
                isFound = true;
                countryID = (int)country["CountryID"];
                countryName = (string)country["CountryName"];
            }
            return isFound;
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

    }
}

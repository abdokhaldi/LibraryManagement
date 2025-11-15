using DVLD_DataAccess.Countries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BussinessLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string  CountryName { get; set; }

        private clsCountry(int countryID, string countryName)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
        }
        public clsCountry()
        {
            this.CountryID = 0;
            this.CountryName = "";
        }

        public static clsCountry FindCountryById(int id)
        {
            int countryID = 0;
            string countryName = "";
            if (DataAccessCountry.GetCountry(id, ref countryID, ref countryName))
            {
                return new clsCountry(countryID, countryName);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetCountriesList()
        {
            return DataAccessCountry.GetCountries();
        }

    }
}

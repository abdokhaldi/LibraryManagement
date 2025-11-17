using DTO_LibraryManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_LibraryManagement
{
    public class SmallPersonRepository
    {
        public static List<SmallPersonDTO> GetPersonAutoSearch(string searchTerm)
        {
            List<SmallPersonDTO> people = null;
            string query = @"SELECT * FROM SmallPeople WHERE FullName LIKE @searchTerm";
            var parameters = new Dictionary<string, (SqlDbType, object, int?)>
            {
                ["@searchTerm"] = (SqlDbType.NVarChar, searchTerm, null),
            };
            using var reader = SqlHelper.ExecuteReaderWildCard(query, CommandType.Text, parameters);
            while (reader != null && reader.Read())
            {
                people = new()
                {
                    new SmallPersonDTO
                    {
                        PersonID = Convert.ToInt32(reader["PersonID"]),
                        FullName = reader["FullName"].ToString(),
                    }
                };
            }
            return people;
        }

    }
}

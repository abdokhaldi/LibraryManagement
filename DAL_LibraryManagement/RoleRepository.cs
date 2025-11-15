using DTO_LibraryManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_LibraryManagement
{
    public class RoleRepository
    {
        public static RoleDTO GetRoleByID(int ID)
        {
            string query = @"SELECT * FROM Roles WHERE RoleID=@ID;";
            var parameters =
                new Dictionary<string, (SqlDbType, object, int?)>()
                {
                    ["@ID"] = (SqlDbType.Int,ID,null),
                };
            var reader = SqlHelper.ExecuteReader(query,CommandType.Text,parameters);
            if (reader.Read())
            {
                return new RoleDTO
                {
                    RoleID = Convert.ToInt32(reader["RoleID"]),
                    RoleName = reader["RoleName"].ToString()
                };
                
            }
            return null;
        }
    }
}

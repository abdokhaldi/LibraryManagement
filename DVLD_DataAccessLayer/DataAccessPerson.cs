using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class DataAccessPerson
    {

        public static DataTable GetAllPeople()
        {
            
                string query = @"SELECT PersonID,NationalNo,FirstName,SecondName,
                           ThirdName,LastName,
                           CASE
                               WHEN Gendor=0 THEN 'Male'
                               WHEN Gendor=1 THEN 'Female'
                               ELSE 'Unknown'
                               END AS Gendor,
                           DateOfBirth,Countries.CountryName AS  Nationality,
                           Phone,Email
                           FROM People INNER JOIN Countries
                           ON People.NationalityCountryID=Countries.CountryID;";
            DataTable dt = (DataTable)SqlDataHelper.ExecuteCommand(query,CommandType.Text,null,SqlDataHelper.enExecuteType.ExecuteDataReaderTable);
            return dt;
        }
           

        

        public static int AddNewPerson(string nationalNo, string firstName, string secondName, string thirdName,
           string lastName, int gendor, DateTime? dateOfBirth, string address, int nationalityCountryID, string phone, string email, string imagePath)
        {
              Dictionary<string, object> parameters;

              string query = @"INSERT INTO People(NationalNo,FirstName,SecondName,
                                 ThirdName ,LastName,Gendor,DateOfBirth,Address,NationalityCountryID,Phone, Email,ImagePath)
                             
                               VALUES(@nationalNo, @firstName,@secondName,@thirdName,
                               @lastName,@gendor,@dateOfBirth,@address,@nationalityCountryID,@phone,@email,@imagePath);
                               SELECT SCOPE_IDENTITY();";

             parameters = new Dictionary<string, object>()
                      {
                         {"@nationalNo", nationalNo },
                         {"@firstName", firstName},
                         {"@secondName", secondName},
                         {"@thirdName", thirdName},
                         {"@lastName", lastName},
                         {"@gendor", gendor},
                         {"@dateOfBirth", dateOfBirth},
                         {"@address", address},
                         {"@nationalityCountryID", nationalityCountryID},
                         {"@phone", phone},
                         {"@email", email},
                         {"@imagePath", imagePath},
                    };     
            object result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters,"ExecuteScalar");
            return (result != null && int.TryParse(result.ToString(), out int personID) ? personID : -1);
        } 
        
        public static int checkIfExisting(string field,string paramValue)
        {
            Dictionary<string, object> parameters;
            string query = "SELECT COUNT(*) FROM People WHERE " + field + " =@paramValue";
            parameters = new Dictionary<string, object>()
            {
                {"@paramValue",paramValue}
            };
            object result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,"ExecuteScalar");
            return (result != null && int.TryParse(result.ToString(), out int count) ? count : 0);
        }

        public static bool UpdatePerson(int personID, string nationalNo, string firstName, string secondName, string thirdName,
           string lastName, int gendor, DateTime? dateOfBirth, string address, int nationalityCountryID, string phone, string email, string imagePath)
        {


            string query = @"UPDATE People
                            SET NationalNo=@nationalNo,
                               FirstName=  @firstName,
                               SecondName= @secondName,
                               ThirdName=  @thirdName,
                               LastName=   @lastName,
                               Gendor=     @gendor,
                               DateOfBirth=@dateOfBirth,
                               Address=    @address,
                               nationalityCountryID= @nationalityCountryID,
                               Phone=        @phone,
                               Email=        @email,
                               ImagePath=    @imagePath
                             WHERE PersonID= @personID";
            Dictionary<string, object> parameters;

            parameters = new Dictionary<string, object>()
                     {
                         {"@nationalNo", nationalNo },
                         {"@firstName", firstName},
                         {"@secondName", secondName},
                         {"@thirdName", thirdName},
                         {"@lastName", lastName},
                         {"@gendor", gendor},
                         {"@dateOfBirth", dateOfBirth},
                         {"@address", address},
                         {"@nationalityCountryID", nationalityCountryID},
                         {"@phone", phone},
                         {"@email", email},
                         {"@imagePath", imagePath},
                         {"@personID",personID }
                    };
            var result = SqlDataHelper.ExecuteCommand(query, CommandType.Text, parameters, SqlDataHelper.enExecuteType.ExecuteNonQuery);
            
         if ( int.TryParse(result.ToString(), out int rowsAffected))
            {
                return (rowsAffected > 0);
            }
            else
            {
                throw new Exception($"an error : the updated was failed {personID}. result : {result}");
            }
         }                
                          
        public static bool FindPerson(string field,object input,ref int personID, ref string nationalNo, ref string firstName, ref string secondName,ref string thirdName,
                             ref string lastName, ref int gendor, ref DateTime? dateOfBirth, ref string address,
                             ref int nationalityCountryID, ref string phone, ref string email, ref string imagePath)
        {
            bool isFound = false;
            string query = $"SELECT * FROM People WHERE {field}=@input;";
                
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@input",input}
            };

           Dictionary<string,object> people = (Dictionary<string, object>) SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,SqlDataHelper.enExecuteType.ExecuteDataReaderSingleRowAsDictionary);
            if (people != null) {
                isFound = true;
               
                personID = people["PersonID"]==DBNull.Value?0: (int)people["PersonID"];
                nationalNo = people["NationalNo"] == DBNull.Value ? "" : (string)people["NationalNo"];
                firstName = people["FirstName"] == DBNull.Value ? "" : (string)people["FirstName"];
                secondName = people["SecondName"] == DBNull.Value ? "" : (string)people["SecondName"];
                thirdName = people["ThirdName"] == DBNull.Value ? "" : (string)people["ThirdName"];
                lastName = people["LastName"] == DBNull.Value ? "" : (string)people["LastName"];
               
                gendor = people["Gendor"] == DBNull.Value ? -1 : Convert.ToInt32(people["Gendor"]);
                   
                dateOfBirth = people["DateOfBirth"] == DBNull.Value ? DateTime.Now: (DateTime?)people["DateOfBirth"];
                address = people["Address"] == DBNull.Value ? "" : (string)people["Address"];
                nationalityCountryID = people["NationalityCountryID"] == DBNull.Value ? 0 : (int)people["NationalityCountryID"];
                phone = people["Phone"] == DBNull.Value ? "" : (string)people["Phone"];
                email = people["Email"] == DBNull.Value ? "" : (string)people["Email"];
                imagePath = people["ImagePath"] == DBNull.Value ? "" : people["ImagePath"].ToString();
              }
            return isFound;
            }

        public static bool DeletePerson(int personID)
        {
            object result ;
            string query = @"DELETE FROM People WHERE PersonID=@personID";
            Dictionary<string, object> parameters;
            parameters = new Dictionary<string, object>()
            {
                {"@personID",personID }
            };
            result = SqlDataHelper.ExecuteCommand(query,CommandType.Text,parameters,"ExecuteNonQuery");
            int rowsAffected = 0;
            if (int.TryParse(result.ToString(),out int _rowsAffected))
            {
                rowsAffected = _rowsAffected;
           }
            return (rowsAffected > 0);
        }





        }
     }
                            
                                                    
                                                    
                                  
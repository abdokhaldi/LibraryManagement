using BLL_LibraryManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_ConsoleApp
{
    internal class Program
    {
        private static void PrintObjectProperties(object _object)
        {
            var type = _object.GetType();
            foreach (var prop in type.GetProperties())
            {
                
                    Console.WriteLine($"{prop.Name} : {prop.GetValue(_object)}");
                
                }
        }
        static void Main(string[] args)
        {
            var u = new UserService();
            u.PersonID = 2;
            u.Username = "user3";
            string pass = "user1234";
            u.Password = "";
            u.RoleID = 2;

            OperationResultBLL result = u.Save();
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("new user id :" + u.UserID);
            }else
            {
                Console.WriteLine(result.Message );

            }

        }
           



        }
    }
    
           
      
    

  

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Project_v2.Global_Classes
{
    public class clsCredincial
    {


        public static void StoreCredentials(bool isRememberMeChecked,string filePath, string userName, string password)
        {
            if (!File.Exists(filePath))
            {
                using (var fs = File.Create(filePath)) { } ;
              
            }
            if (isRememberMeChecked)
            {

                using (StreamWriter writer = new StreamWriter(filePath, append: false))
                {
                    string hashedPassword = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
                    writer.WriteLine(userName);
                    writer.WriteLine(hashedPassword);
                }
            }
            else
            {
                File.WriteAllText(filePath, string.Empty);
            }
        }

        public static void GetCredentials(string fileName,ref string userName, ref string password)
        {
            string[] credentialLines = File.ReadAllLines(fileName);
            if (File.Exists(fileName))
            {
                if (credentialLines.Length == 2)
                {
                    userName = credentialLines[0];
                    password = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(credentialLines[1]));
                }
                else
                {
                   userName = "";
                   password = "";
                }

            }

        }

    }
}

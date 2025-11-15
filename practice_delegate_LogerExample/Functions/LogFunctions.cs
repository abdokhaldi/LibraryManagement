using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_delegate_LogerExample.Functions
{
    public class LogFunctions
    {
        
        
        public static void LogToScreen(string message)
        {
            Console.Write(message);
        }
        public static void LogToFile(string message)
        {
            string filePath = "log.txt";
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
         }

        public static void LogToDatabase(string message)
        {
            Console.Write(message);
        }
        
    }
}

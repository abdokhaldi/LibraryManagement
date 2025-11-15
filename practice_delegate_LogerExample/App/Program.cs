using practice_delegate_LogerExample.Core;
using practice_delegate_LogerExample.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_delegate_LogerExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loger logToScreen = new Loger(LogFunctions.LogToScreen);
            Loger logToDatabase = new Loger(LogFunctions.LogToDatabase);
            Loger logToFile = new Loger(LogFunctions.LogToFile);
             
            
            logToScreen.Log("This is log to screen\n");
            logToDatabase.Log("This is log to database");
            logToDatabase.UnLog(LogFunctions.LogToDatabase);
            logToFile.Log("This is log to file");

           
       
        }
    }
}



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger_using_delegation
{
    public class Loger
    {

        public delegate void LogerScreen(string message);
        private LogerScreen _log ;

        public Loger(LogerScreen log)
        {
            _log = log;
        }

        public void LogMessage(string message)
        {
            _log(message);
        }

    }


    internal class Program
    {
        
        public static void LogToScreen(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogToFile(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogToDatabase(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            var logToScreen = new Loger(LogToScreen);
            var logToFile = new Loger(LogToFile);
            var logToDatabase = new Loger(LogToDatabase);

            logToScreen.LogMessage("Log To Screen");
            logToFile.LogMessage("Log To File");
            logToDatabase.LogMessage("Log To Database");
        }
    }
}

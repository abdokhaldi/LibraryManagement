#define BEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceAttributes
{
    internal class Program
    {
        [Conditional("BEBUG")]
        public static void Method1(string message)
        {
             Console.WriteLine(message);
        }

        [Obsolete("this method will be depricated in the future")]
        public static int Method2(string message)
        {
          //  Console.WriteLine(message );
            return 99;
        }
        static void Main(string[] args)
        {
            Method1("Message 1");


            Method2("Message 2");

        }
    }
}

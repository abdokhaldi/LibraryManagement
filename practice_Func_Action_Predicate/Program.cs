using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_Func_Action_Predicate
{
    
    internal class Program
    {
        static Action<int, int> PrintResult = print_result;
        static Func<int,int> PowerOfNumber = power_of_number;
        static Predicate<object> IsNumber = is_number;
        static void print_result(int x, int y)
        {
            int result = x + y;
            Console.WriteLine("the result is : " + result);
        }
        static int power_of_number(int x)
        {
            return (x * x);
        }

        static bool is_number(object x)
        {
            bool isNum = int.TryParse(x.ToString(), out int num);
         if (isNum) {
                return true;
            }else
            {
                return false;
            }
          }
        static void Main(string[] args)
        {
            PrintResult(5,7);
            int Power = PowerOfNumber(5);
            Console.WriteLine();

            Console.WriteLine(Power);

            bool isNumber = IsNumber(0);
            if (isNumber)
            {
                Console.WriteLine("it is a number");
            }else
            {
                Console.WriteLine("it is not a number");
            }

        }

        
    }
}

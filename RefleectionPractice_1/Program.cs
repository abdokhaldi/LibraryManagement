using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RefleectionPractice_1
{
    public class MyClass
    {
        public int property1 { get; set; }
        public void Method1()
        {
            Console.WriteLine("this is method 1");
        }
        public void Method2(int val1, int val2)
        {
            Console.WriteLine($"value1 : {val1} value2 : {val2}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Type myClassType = typeof(MyClass);

            Console.WriteLine("Information :");
            Console.WriteLine($"Name : {myClassType.Name}");
            Console.WriteLine($"FullName : {myClassType.FullName}");

            Console.WriteLine("get properties :");
            var properties = myClassType.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.PropertyType} {property.Name}");
            }

            Console.WriteLine();
            Console.WriteLine("get Methods :");
            var methods = myClassType.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"{method.ReturnType} {method.Name} {GetParameters(method.GetParameters())}");
            }

            Console.WriteLine();
            Console.WriteLine("get Methods :");

        }

        static string GetParameters(ParameterInfo[] parameters)
        {
            return string.Join(", ", parameters.Select(parameter => $"{parameter.ParameterType} {parameter.Name}"));
        }
    }
}

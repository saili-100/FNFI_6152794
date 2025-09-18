using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
   class DataTypes
    {
        static void Main()
        {
            /* datatypes primitive int float byte long double*/
            int iVal = 123;
            long lval = 234324343;
            float fval = 10.6f;
            double dValue = 23434.2344;
            char strText = 'a';
            bool bValue = true;
           Console.WriteLine($"{iVal} {lval} {fval} {dValue}{strText}{bValue}");
            /* All datatypes in C# are based on common Type System (CTS) of .Net framework
             CTS provides a common set of datatypes for all lang of .Net
            ----->Prinitive types (Structs) or value types    ----> reference typesd (Classes)
            */
            DisplayUserDetails();
            TypeCasting();

        }
        static void DisplayUserDetails()
        {   Console.WriteLine("Enter the Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the age");
            int iAge = int.Parse( Console.ReadLine());
            Console.WriteLine("Enter mobile number");
            long Mobile = long.Parse( Console.ReadLine());
            Console.WriteLine($" Name is : {name} \n Age is {iAge} \n Mobile number is : {Mobile}");
        }


        static void TypeCasting()
        {
            // Convert form int to long
            int num1 = 123;
            long num2 = num1; // implicit conversion from int to double 
            double num3 = 1234.5; // implicit conversion from int to double
            num2 = (long)num3;

            // we can use Convert Class to convert from one type to other 
            num2 = Convert.ToInt64(num3);
            Console.WriteLine($"{num1}{num2}{num3}");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Enums are user defined data type (UDT) Enums are User Defined Data Types(UDTs) that are used to define Named Constants. If U have a set of related constants, you can use an enum to define them in a single type.
 * All Enum values are internally of type int, but you can specify a different underlying type if needed and it should be integral type only.*/

namespace SampleConApp
{
    enum Days
    {
        Sunday = -1,
        Monday,Tuesday,
        Wednesday,Thursday,
        Friday,Saturday,
    }
    internal class EnumsExample
    {
        static void Main(string[] args)
        {
            Days d1 = Days.Friday;
            Console.WriteLine(d1);
            Console.WriteLine($"The selected date is {d1} and its integral value is {(int)d1}. Its internal data type is {d1.GetTypeCode()}");


            Console.WriteLine("Enter the day from the List below U want to start work");
            Array values = Enum.GetValues(typeof(Days));//Gets the values of the enum. The Enum reference is obtained using typeof operator.
            foreach (var value in values) //Iterate through the values of the array
            {
                Console.WriteLine(value);//display each item 
            }
            Console.WriteLine("Enter day you wish :\n");
            string dayInput = Console.ReadLine();
            Days day = Enum.Parse<Days>(dayInput); // true for case-insensitive parsing
            Console.WriteLine("The selected day is " + day);
        }
    }
}

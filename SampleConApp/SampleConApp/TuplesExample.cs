using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class TuplesExample
    {
        static void Main(string[] args)
        {
            var my_tuple = ("Saili", 24);
            Console.WriteLine(my_tuple);
            Console.WriteLine($"First Item: {my_tuple.Item1},Second Item: {my_tuple.Item2}");

            // We can have named tuples as well like key value pair
            var person = (Name: "Krishna", Age: 25, Country: "India");
            Console.WriteLine($"Name:{person.Name} from {person.Country} and age is {person.Age}");

            // Can have coordinates too 
            var (longit, latid) = GetCoordinates();
            Console.WriteLine($"The coordinates are ({longit},{latid}");
        }
        static (double,double) GetCoordinates()
        {
            return ((123.45, 6874.5));
        }
    }
}

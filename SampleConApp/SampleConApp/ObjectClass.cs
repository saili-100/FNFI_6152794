using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SampleConApp
{
    internal class ObjectClass
    {
        static void Main(string[] args)
        {
            object obj = 10; //Boxing implicit conversion of any type to object
            Console.WriteLine("The data type is " + obj.GetType().Name); //getting/display the name of data type stored in object. Reads  from right to left
            obj = "Sample Text";
            Console.WriteLine("The data type is " + obj.GetType().Name);
            obj = 12345.3f;
            Console.WriteLine("The data type is " + obj.GetType().Name);

            // Unbox the object to get the original type or perform any operation obj++ won't work we need to unbox it related to the original type. We unbox an object by explicit casting it to the original type.
            float f =(float)obj; //unboxing explicit conversion of object to float
            f++; // any operation can be performed on the unbox value.
            Console.WriteLine("The unboxed value is " + f);

        }
    }
}

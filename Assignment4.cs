using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SailiAssignment
//Write a program that creates an array and displays the contents of the array.The array should be created dynamically.It means that the size, type should be set by the user of the Program. Take inputs for the values also.Finally it should display the values of the array.
{
    internal class Assignment4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the data type of the array int,double,string");
            string dataType = Console.ReadLine();

            Array array_result = CreateArray(size, dataType);
            Console.WriteLine("Formatted array is:");
            foreach (var item in array_result)
            {
                Console.WriteLine($"{item}");
            }

            // function to create array 
            static Array CreateArray(int size, string dataType)
            {
                switch (dataType)
                {
                    case "int":
                        int[] intarr = new int[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.WriteLine($" Enter element {i + 1}");
                            intarr[i] = int.Parse(Console.ReadLine());

                        }
                        return intarr;

                    case "float":
                        float[] floatarr = new float[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.WriteLine($"Enter element {i + 1}");
                            floatarr[i] = float.Parse(Console.ReadLine());

                        }
                        return floatarr;

                    case "double":
                        double[] doublearr = new double[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.WriteLine($"Enter element {i + 1}");
                            doublearr[i] = double.Parse(Console.ReadLine());
                        }
                        return doublearr;

                    case "string":
                        string[] stringarr = new string[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.WriteLine($"Enter element {i + 1}");
                            stringarr[i] = (Console.ReadLine());
                        }
                        return stringarr;
                    default:
                        Console.WriteLine("Invalid data type.");
                        return new object[0];


                }
            }
        }
    }
}


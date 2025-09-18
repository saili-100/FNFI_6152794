using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class ArraysExample
    {
        static void Main(string[] args)
        {
            //SingleDimensionalExample();
            //MultiDimensionalExample();
            JaggedExample();


        }

        private static void SingleDimensionalExample()
        {
            string[] names = new string[5];
            names[0] = "Saili";
            names[1] = "Shweta";
            names[2] = "Amulya";
            names[3] = "Supritha";
            names[4] = "Krishna";

            for (int index = 0; index < names.Length; index++)
            {
                Console.WriteLine($"{names[index]} having index as {index}");
            }
            //ctrl . generate method.
        }

        private static void MultiDimensionalExample()
        {
            int[,] Marks = new int[4, 5];//4x5 array, 4 rows and 5 columns
            //Assigning values to the array elements
            Marks = new int[,]
            {
                { 90, 85, 80, 75, 70 }, //Row 0
                { 88, 82, 78, 74, 68 }, //Row 1
                { 92, 89, 84, 79, 73 }, //Row 2
                { 95, 90, 85, 80, 75 } //Row 3
            };

            //Display the elements in a Matrix format
            for (int i = 0;i < Marks.GetLength(0); i++)
            {
                for (int j = 0; j < Marks.GetLength(1); j++)
                {
                    Console.Write($"{Marks[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        private static void JaggedExample()
        {
            //having classes in school of varaible number of students in each class
            int[][] school = new int[3][]; // Declare a jagged array with 3 rows
            school[0] = new int[5] { 90, 85, 80, 75, 70 }; // Row 0 with 5 columns
            school[1] = new int[4] { 88, 82, 78, 74 }; // Row 1 with 4 columns
            school[2] = new int[3] { 92, 89, 84 }; // Row 2 with 3 columns

            for (int i = 0; i < school.Length; i++)
            {
                Console.Write($"Row {i}: ");
                foreach (int no in school[i]) // Iterate through each row
                {
                    Console.Write($"{no} ");
                }
                Console.WriteLine();
            }
        }
    }


    }


    

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SailiAssignment
{
    internal class Assignment2
    {
        //Write a function that takes an array of numbers and it should display the Odd and Even numbers
        // Handle error
        static void Main(string[] args)
        {
            NumbersArray();
        }

        static void NumbersArray()
        {

        RETRY:
            try
            {
                Console.WriteLine("Enter size of array you wish :");
                int val = int.Parse(Console.ReadLine());
                int[] numberarray = new int[val];
                for (int item = 0; item < val; item++)
                {
                    Console.WriteLine($"Enter number {item + 1}");
                    numberarray[item] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Elements of array are:");
                //Console.WriteLine("Even numbers are:");
                foreach (int element in numberarray)
                {

                    if (element % 2 == 0)
                    {

                        Console.WriteLine($"{element} is even");
                    }
                    else
                    {
                        Console.WriteLine($"{element} is odd");

                    }


                }

            }
            catch (OverflowException)
            {
                Console.WriteLine($"Input must be within {int.MinValue} and {int.MaxValue}");
                goto RETRY;
            }
            catch (FormatException)
            {
                Console.WriteLine("Input should be a valid no");
                goto RETRY; 
            }

        }   
        }

    }


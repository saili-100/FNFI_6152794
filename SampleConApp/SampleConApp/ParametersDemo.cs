using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class ParametersDemo
    {
        public static void NormalParameter(int x)
        {
            x = 123;
            Console.WriteLine($"normal parameter {x}");

        }
        public static void AddFunc(int x, int y, out double result) => result = x + y; //out parameter

        public static long AddNumbers(params int[] numbers)
        {
            //params allows the user to pass any no of args while calling the method
            long sum = 0;
            foreach (int x in numbers)
            {
                sum += x;
            }
            return sum;
        }
        //public static void ArithmeticFunction(int first, int second, ref double addedvalue, ref double subtractedvalue, ref double multipliedValue, ref double dividedValue)
        //{
        //    addedvalue = first + second;
        //    subtractedvalue = first - second;
        //    multipliedValue = first * second;
        //    if (second != 0)
        //    {
        //        dividedValue = first / second;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Number can't be divide by zero");
        //    }

        static void Main(string[] args)
            {
                int x = 10;
                NormalParameter(x);
                Console.WriteLine("X value after returning the function: " + x);

                double result;
                AddFunc(10, 20, out result); // retains the result in the out parameter. even after the method call, the out parameter retains the value assigned in the method.
                Console.WriteLine("The result :" + result);

                //Console.WriteLine(AddNumbers(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)); 
                //int first =0, second =0,addedValue =0,subtractedvalue=0,multipliedValue =0,dividedValue=0;
                //ArithmeticFunction(first,second,ref addedValue,ref subtractedvalue,ref multipliedValue,ref dividedValue);
            }
        }
    }

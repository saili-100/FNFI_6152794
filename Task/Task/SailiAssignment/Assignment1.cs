using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailiAssignment
{
    internal class Assignment1
    {
        //Write a program that displays the range of all the floating and integral types of.NET CTS
        //integral type byte short int long
        //floating type float double decimal
        static void Main(string[] args)
        {
            RangeOfFloatingIntegralType();
        }
        static void RangeOfFloatingIntegralType()
        {
            Console.WriteLine("!! Integral Types are !! :\n");
            Console.WriteLine($"Range of byte is {byte.MinValue} to {byte.MaxValue} ");
            Console.WriteLine($"Range of short is {short.MinValue} to {short.MaxValue} ");
            Console.WriteLine($"Range of int is {int.MinValue} to {int.MaxValue} ");
            Console.WriteLine($"Range of long is {long.MinValue} to {long.MaxValue} \n");
            Console.WriteLine("!! Floating Types are !! :\n");
            Console.WriteLine($"Range of float is {float.MinValue} to {float.MaxValue} ");
            Console.WriteLine($"Range of double is {double.MinValue} to {double.MaxValue} ");
            Console.WriteLine($"Range of decimal is {decimal.MinValue} to {decimal.MaxValue} ");



        }
    }
}

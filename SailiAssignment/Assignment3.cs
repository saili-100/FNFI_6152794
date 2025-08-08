using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SailiAssignment
{
    internal class Assignment3
    {
        //Write a Math Calc Program that allows Users to enter the values and operation and the Program should display the result based on the operator the user has typed.It should be in a loop until the user specifies to close it.
        static void Main(string[] args)
        {
            MathCalcProgram();
        }

        static void MathCalcProgram()
        {
            bool condition = false;
            do
            {
               
                Console.WriteLine("Enter number1: ");
                int num1 = int.Parse((Console.ReadLine()));

                Console.WriteLine("Enter number2: ");
                int num2 = int.Parse((Console.ReadLine()));

                Console.WriteLine("Enter operator + - * /");
                string operators = Console.ReadLine();
                switch (operators)
                {
                    case "+":

                        int addition = num1 + num2;
                        Console.WriteLine($"Addition of {num1} + {num2} is {addition}");
                        break;
                    case "-":
                        int subtraction = num1 - num2;
                        Console.WriteLine($"Subtraction of {num1} - {num2} is {subtraction}");
                        break;
                    case "*":
                        int multiply = num1 * num2;
                        Console.WriteLine($"Multiplication of {num1} * {num2} is {multiply}");
                        break;
                    case "/":

                        if (num2 != 0)
                        {
                            int division = num1 / num2;
                            Console.WriteLine($"Division of {num1}/{num2} is {division}");

                        }
                        else
                        {
                            Console.WriteLine("Invalid number");
                        }
                        break;


                    default:
                        Console.WriteLine("Invalid Choice");
                        break;




                }
                Console.WriteLine("Do you want to continue? yes or no :");
                string decision =Console.ReadLine();
                if(decision == "yes")
                {
                    condition = true;
                }
                else
                {
                    Console.WriteLine("Thank you");
                    condition = false;
                }



            } while (condition);
        }















    }
        }


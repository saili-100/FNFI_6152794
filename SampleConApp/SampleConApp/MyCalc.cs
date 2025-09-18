//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SampleConApp
//{
//    class MyCalc
//    {
//        static void Main()
//        {
//            Console.WriteLine("Enter num1\n");
//            int num1 = int.Parse(Console.ReadLine());
//            Console.WriteLine("Enter num2\n");
//            int num2 = int.Parse(Console.ReadLine());

//            Console.WriteLine($"{num1} \n {num2}");
//            Console.WriteLine("Enter choice");
//            string choices = " 1. Addition \n 2. Subtraction 3. Multiplication 4. Division";
//            Console.WriteLine(choices);
//           int choice = int.Parse(Console.ReadLine());
           
//                switch (choice)
//                {
//                    case 1:
//                        Console.WriteLine(num1 + num2);
//                        break;
//                    case 2:
//                        Console.WriteLine(num1 - num2);
//                        break;
//                    case 3:
//                        Console.WriteLine(num1 * num2);
//                        break;

//                    case 4:
//                        Console.WriteLine(num1 / num2);
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice");
//                        break;
//                }
           






            
//            /*
//             using System;
// //Todo: Create a Arithematic Calc Program taking inputs from the User:
// //2 Values to add, subtract, multiply or divide.
// //Option to select add, subtract, multiply or divide
// //Display the result on the Console. 

// namespace SampleConApp
// {
//     internal class Ex03CalcProgram
//     {
//         static string GetStringValue(string question)
//         {
//             Console.WriteLine(question);
//             return Console.ReadLine();
//         }
//         static double GetDoubleValue(string question)
//         {
//             Console.WriteLine(question);
//             return double.Parse(Console.ReadLine());
//         }

//         static double GetResult(double val1, double val2, string operand)
//         {
//             switch(operand)
//             {
//                 case "+": return val1 + val2;
//                 case "-": return val1 - val2;
//                 case "X": return val1 * val2;
//                 case "/": return val1 / val2;
//                 default:
//                     Console.WriteLine("Invalid Choice");
//                     return 0;
//             }
//         }
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Welcome to Calc Program");
//             bool processing = false;
//             do
//             {
//                 Console.Clear();
//                 double val1 = GetDoubleValue("Enter the First Value");

//                 double val2 = GetDoubleValue("Enter the second Value");

//                 string operand = GetStringValue("Enter the Operands as + or - or X or /").ToUpper();

//                 double result = GetResult(val1, val2, operand);

//                 Console.WriteLine("The result: {0}", result);

//                 string choice = GetStringValue("Press Y to continue or N to quit");
//                 processing = choice.ToUpper() == "Y" ? true : false;
//             } while(processing);
//         }

//             */












//        }






//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace SampleConApp
//{
//    class DBFailureException : Exception
//    {
//        public DBFailureException()
//        {

//        }
//        public DBFailureException(string message) : base(message)
//        {

//        }
//        public DBFailureException(string message, Exception innerException) : base(message, innerException)
//        {

//        }
//    }
//    internal class Ex014ExceptionHandling
//    {
//        static void Main(string[] args)
//        {
//            //TryCatchExample();
//            /*
//            Retry:
//                try
//                {
//                    ThrowKeywordExample();
//                }
//                catch (UnauthorizedAccessException ex) { 
//                    Console.WriteLine(ex.Message);
//                }
//            */
//            try
//            {
//                CustomExceptionExample();
//            }
//            catch (DBFailureException ex)
//            {
//                Console.WriteLine($"Custom Exception Caught:{ex.Message}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"General Exception Caught:{ex.Message}");
//            }
//            finally
//            {
//                Console.WriteLine("The execution completed successfully");
//            }

//        }

//        private static void CustomExceptionExample()
//        {
//            bool isConnected = true;
//            Console.WriteLine("Code to connect DB");
//            isConnected = false;
//            if (!isConnected)
//            {
//                throw new DBFailureException("The connection to DB failed");
//            }
//        }

//        private static void ThrowKeywordExample()
//        {
//            Console.WriteLine("Enter the Name : ");
//            string name = Console.ReadLine();
//            Console.WriteLine("Enter the Password : ");
//            string pwd = Console.ReadLine();
//            if (pwd == "admin" && name == "admin")
//            {
//                Console.WriteLine("Successfully Logged In");
//            }
//            else
//            {
//                throw new UnauthorizedAccessException("Invalid username or password");
//            }
//        }

//        private static void TryCatchExample()
//        {
//        Retry:
//            try
//            {
//                Console.WriteLine("Enter the age : ");
//                int age = int.Parse(Console.ReadLine());
//                Console.WriteLine($"The age is : {age}");
//                Console.WriteLine("Enter the num1 : ");
//                int num1 = int.Parse(Console.ReadLine());
//                Console.WriteLine("Enter the num2 : ");
//                int num2 = int.Parse(Console.ReadLine());
//                long a = num1 / num2;
//            }
//            catch (FormatException ex)
//            {
//                Console.WriteLine($"The System generate message is : {ex.Message}");
//                Console.WriteLine("Enter the valid age no.");
//                goto Retry;
//            }
//            catch (OverflowException ex1)
//            {
//                Console.WriteLine($"The System generate message is : {ex1.Message}");
//                Console.WriteLine($"Input value must be within {int.MinValue} and  {int.MaxValue}");
//                goto Retry;
//            }
//            catch (ArgumentException ex2)
//            {
//                Console.WriteLine($"The System generate message is : {ex2.Message}");
//                goto Retry;
//            }
//            catch (Exception ex3)
//            {
//                Console.WriteLine($"The System generate message is : {ex3.Message}");
//                Console.WriteLine("Divide by Zero is not possible");
//            }
//            finally
//            {
//                Console.WriteLine("The finally block is always executes It is always used to clean the resources,close files or perform any run operation");
//            }
//        }
//    }
//}







using System;
using System.Collections.Generic;//This is the namespace for Generics.

//Generics is a feature of .NET that can allow to create classes, methods and interfaces that can work on any kind of data type. They are similar to templates in C++. They are said to be type-safe, meaning that they can enforce type constraints at compile time, reducing runtime errors. U dont have to unbox the data when U use generics, as they are already type-safe.
//namespace SampleConApp
//{
//    internal class Ex19GenericsDemo
//    {
//        static void Main(string[] args)
//        {
//            listExample();
//        }

//        private static void listExample()
//        {
//            List<string> names = new List<string>();
//            names.Add("John");//Add only strings to the list.
//            names.Add("Jane");
//            names.Add("Doe");
//            names.Add("Smith");
//            names.Add("Alice");
//            names.Add("Bob");
//            names.Insert(2, "Charlie");//Insert at index 2. This will shift the other items to the right.

//            //Iterating through the list using foreach loop. foreach is a easy way to iterate through a collection in C#. It is forward-only and readonly. U can move by 1 number at a time.
//            foreach (string name in names)
//            {
//                Console.WriteLine(name.ToUpper());//No unboxing is required as the list is of type string.
//            }
//            //Like ArrayList, here also U can insert, remove, and search for items in the list from any where.
//            string nameToFind = ConsoleUtil.GetInputString("Enter a name to find: ");
//            if (!names.Contains(nameToFind))
//            {
//                Console.WriteLine("UR Entered Name does not exist");
//            }
//            else
//            {
//                for (int i = 0; i < names.Count; i++)
//                {
//                    if (names[i] == nameToFind)
//                    {
//                        Console.WriteLine($"UR Entered Name is found at index {i}");
//                        break; //Exit the loop once the name is found.
//                    }
//                }
//            }

//        }
//    }
//}

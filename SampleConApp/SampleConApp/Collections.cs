using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class Collections
    {
        static Hashtable users = new Hashtable();
        static void Main(string[] args)
        {
            //ArrayListExample();
            //HashtableExample();
            UserLoginApp();

        }
        static void ArrayListExample()
        {
            ArrayList list = new ArrayList();
            list.Add(234);
            list.Add(123);// adds the element to the bottom of the collection
            list.Add(345);
            list.Add(500);
            //list.Add("jo");
            list.Add(143);
            list.Remove(354);
            Console.WriteLine("The total :" + list.Count);
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            for (int j = 0; j < list.Count; j++)
            {
                if ((int)list[j] == 55)
                {
                    Console.WriteLine("Item found");
                }
                else
                {
                    continue;
                }
            }
        }
        private static void HashtableExample()
        {
            Hashtable table = new Hashtable();
            table.Add("obj1", "Sample1");
            table.Add("obj2", "Sample2");
            table.Add("obj3", "Sample3");
            table.Add("obj4", "Sample4");
            table.Add("obj5", "Sample5");

           foreach(string key in table.Keys) {
                Console.WriteLine($"key : {key},Value : {table[key]}");

            }
        }

        static class ConsoleUtil
        {
            public static string GetInputString(string question)
            {
                Console.WriteLine(question);
                return Console.ReadLine();
            }
            public static int GetInputInt(string question)
            {
                return int.Parse(GetInputString(question));
            }
            public static double GetInputDouble(string question) => double.Parse(GetInputString(question));
        }


        private static void UserLoginApp()
        {
            do
            {
                string choice = ConsoleUtil.GetInputString("Press R for Register and L for Login");
                if (choice.ToUpper() == "R")
                {
                    registerUser();
                }
                else
                {
                    validateUser();
                }
            } while (true);
        }

        private static void validateUser()
        {
            Console.WriteLine("Welcome to Login Page");
            string username = ConsoleUtil.GetInputString("Enter the Username");
            string password = ConsoleUtil.GetInputString("Enter the Password");
            if (!users.ContainsKey(username))
            {
                Console.WriteLine("Invalid Username");
                return;
            }
            else if (users[username].ToString() != password)
            {
                Console.WriteLine("Invalid Password");
                return;
            }
            else if (users[username].ToString() == password)
            {
                Console.WriteLine($"Welcome to the user {username}");
            }
        }
        private static void registerUser()
        {
            Console.WriteLine("Welcome to Registration Page");
            string username = ConsoleUtil.GetInputString("Enter the Username");
            string password = ConsoleUtil.GetInputString("Enter the Password");
            if (users.ContainsKey(username))
            {
                Console.WriteLine("User is already registered");
                return;
            }
            users[username] = password;//Adds a key and assigns a value to that key. If the Key exists, it would replace the value. 
            Console.WriteLine("User registered Successfully");

        }

    }
}

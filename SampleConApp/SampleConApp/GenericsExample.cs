using System;
using System.Collections.Generic; // namespace for generics
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Generics is a feature of .NET that can allow to create classes, methods and interfaces that can work on any kind of data type. They are similar to templates in C++. They are said to be type-safe, meaning that they can enforce type constraints at compile time, reducing runtime errors. U dont have to unbox the data when U use generics, as they are already type-safe.

namespace SampleConApp
{
    
    internal class GenericsExample
    {
        static void Main(string[] args)
        {
            DictionaryExample();
            //HashSetOnEmployeeExample();
            //ListExample();
            //HashSetExample();
        }

        private static void DictionaryExample()
        {
            Dictionary<string,string> users = new Dictionary<string,string>();
            users.Add("John", "apple123");
            users.Add("Bob", "mango123");
            users.Add("Joe", "test123");
            users.Add("Andrews", "apple123");
            users["Jenny"] = "pass123";

            var username = ConsoleUtil.GetInputString("Enter the username to login :");
            var password = ConsoleUtil.GetInputString("Enter the password:");
            if(users.ContainsKey(username) && users[username] == password)
            {
                Console.WriteLine("Your login is successful");
            }
            else
            {
                Console.WriteLine("Login failed. Please check the username and password");
            }
//try for sign in --> if existing user sign in else new user add new user
        }
        //private static void HashSetExample()
        //{
        //    HashSet<string> names = new HashSet<string>();
        //    names.Add("John");
        //    names.Add("Jane");
        //    names.Add("Doe");
        //    if(!names.Add("John"))
        //        Console.WriteLine("John is already the member of the team");
        //    Console.WriteLine("The total members of the team: " + names.Count + "\n" + "\nTeam members are:");
        //    foreach (string name in names)
        //    {
        //        Console.WriteLine(name);
        //        //No unboxing is required as the list is of type string.
        //    }
        //}




        //private static void ListExample()
        //{
        //    List<string> names = new List<string>();
        //    names.Add("Saili");//Add only strings to the list.
        //    names.Add("Shweta");
        //    names.Add("Amulya");
        //    names.Add("Supritha");
        //    names.Add("Anuja");
        //    names.Add("Dipal");
        //    names.Insert(2, "Priti");
        //    foreach (string name in names)
        //    {
        //        Console.WriteLine(name.ToUpper());
        //        //No unboxing is required as the list is of type string.
        //    }
        //    string nameToFind = ConsoleUtil.GetInputString("Enter a name to find: ");
        //    if (!names.Contains(nameToFind))
        //        {
        //            Console.WriteLine("Entered Name does not exist");
        //        }
        //    else
        //        {
        //            //for (int i = 0; i < names.Count; i++)
        //            //{
        //            //    if (names[i] == nameToFind)
        //            //    {
        //            //        Console.WriteLine($"Entered Name is found at index {i}");
        //            //        break; //Exit the loop once the name is found.
        //            //    }
        //            //}
        //            var index = names.IndexOf(nameToFind);
        //        //will return the index of the name if found , otherwise -1 
        //        Console.WriteLine($"Entered Name is found at index {index}");
        //    }
        //    }
        //}
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

        //    private static void HashSetOnEmployeeExample()
        //    {
        //        //In HashSet, the items are compared using the GetHashCode() and Equals() methods. If two items have the same hash code, then they are compared with the Equals method and then are considered equal/unequal.
        //        HashSet<Employee> employees = new HashSet<Employee>();
        //        employees.Add(new Employee { EmpID = 1, EmpName = "John", EmpAddress = "New York", EmpSalary = 50000,});
        //        employees.Add(new Employee { EmpID = 2, EmpName = "Jane", EmpAddress = "Los Angeles", EmpSalary = 60000 });
        //        employees.Add(new Employee { EmpID = 3, EmpName = "Doe", EmpAddress = "Chicago", EmpSalary = 55000 });
        //        employees.Add(new Employee { EmpID = 4, EmpName = "Alice", EmpAddress = "Houston", EmpSalary = 70000 });
        //        employees.Add(new Employee { EmpID = 5, EmpName = "Bob", EmpAddress = "Phoenix", EmpSalary = 65000});
        //        employees.Add(new Employee { EmpID = 6, EmpName = "John", EmpAddress = "India", EmpSalary = 50000});
        //        employees.Add(new Employee { EmpID = 1, EmpName = "Sam", EmpAddress = "New York", EmpSalary = 50000});

        //        foreach (Employee emp in employees)
        //        {
        //            Console.WriteLine($"{emp.EmpName} having emp id as {emp.EmpID} , earns a salary of {emp.EmpSalary:C} leaves in {emp.EmpAddress}");
        //        }
        //    }

    }

}




//using SampleVBNet.DataLayer;
//using SampleVBNet.Entities;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

////LINQ is a libreary for performing queries on objects,XML and other kinds of data.It has been extended to even SQL server.

////If U can get a collection of data from an external source, U can perform database kind of queries(Reading) from the collection instead of reading the whole collection all the time. LINQ help in optimizing the search in the collection and returns the specific data from the master collection. 
////LINQ was introduced in .NET 3.5 and made full fledged in .NET 4.0.
////LINQ comes with a set of keywords(from, group, order, by, where, select) as well as Extension methods that is applicable on all Collection classes. 
////A Collection class is one that implements IEnumerable<T> interface. 
////Extension methods are methods that are added at runtime to the instance without breaking the class. 
////LINQ Extension methods are available under System.Linq. 

//namespace SampleVBNet
//{
//    public class Ex04Linq // Changed to public
//    {
//        static List<Employee> masterData = GetAllEmployees();

       
//        public static void Main(string[] args) // Changed to public static
//        {
//            Console.WriteLine("Hello from Ex04Linq!");
//            readNamesAndSalarys();
//        }

//        private static void readNamesAndSalarys()
//        {
//            var results = from rec in masterData
//                          orderby rec.EmpSalary descending
//                          select new { rec.EmpName, rec.EmpSalary };
//            foreach (var item in results)
//            {
//                Console.WriteLine(item);
//            }
//        }
//        private static void readNamesAndAddress()
//        {
//            var results = from rec in masterData
//                          select new { rec.EmpName, rec.EmpAddress };
//            foreach (var result in results)
//            {
//                Console.WriteLine($"{result.EmpName} on {result.EmpAddress}");
//            }
//        }

//        private static void readonlyNames()
//        {
//            var results = from emp in masterData
//                          select emp.EmpName;
//            foreach (var desc in results)
//            {
//                Console.WriteLine(desc);
//            }
//        }
//        //private static void joinExampleGroupByDept()
//        //{
//        //    var results = from emp in masterData join dept in masterDepts on emp.DeptId equals dept.DeptId group new { emp, dept } by dept.DeptName into gr orderby gr.key ascending select gr;

//        //    foreach (var group in results)
//        //    {
//        //        Console.WriteLine("EMPLOYEES UNDER "+group.Key);
//        //        foreach (var rec in group)
//        //        {
//        //            Console.WriteLine($"{rec.emp.EmpName} earns {rec.emp.EmpSalary}");

//        //        }
//        //        Console.WriteLine("\n\n\n");

//        //    }


//        //}

//        //private static void joinAllEmployessWithDepts()
//        //{
//        //    var results = from emp in masterData
//        //                  join dept in masterDepts
//        //                  on emp.DeptId equals dept.DeptId into gr
//        //                  from subDept in gr.DefaultIfEmpty() // this is a left outer join
//        //                  select new
//        //                  {
//        //                      emp.EmpName,
//        //                      emp.EmpSalary,
//        //                      emp.EmpAddress
//        //                    DeptName = subDept?.DeptName ?? "No dept" //subDept ? means not null give DeptName else give No dept.



//        //                  };
//        //     foreach (var emp in results)
//        //    {
//        //        Console.WriteLine($"{emp.EmpName} is working in {emp.DeptName}");
            
            
//        //    }
        
//        //}
//        }
//    }

//// defaultIfEmpty() enseure that if no                 it will return 


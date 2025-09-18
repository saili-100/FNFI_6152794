using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OperatorOverloading
{

    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public double EmpSalary { get; set; }
        //  //Overloading an operator is done by creating a static method with the keyword 'operator' followed by the operator symbol.
        public static Employee operator + (Employee lhs, int rhs)
        {
            lhs.EmpSalary += rhs;
            return lhs;
        }
        public static Employee operator - (Employee lhs, int rhs)
        {
            lhs.EmpSalary -= rhs;
            return lhs;
        }

    }
}
namespace SampleConApp
{
    using OperatorOverloading;

    internal class OperatorOverloadingExample
    {
        static void Main(string[] args)
        {
            OperatorOverloading.Employee emp = new OperatorOverloading. Employee { EmpID = 1, EmpName = "Saili", EmpSalary = 15000 };
            emp += 5000; 
            emp -= 2000; // Using the overloaded operators
            Console.WriteLine("The Incremented Salary is " + emp.EmpSalary);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 
namespace SampleVBNet

{
    using SampleVBNet.Data1;

    
    internal class Ex06LinqToSqlDemo
    {
        static void Main(string[] args)
        {
            //insertEmployee();
            //updateEmployee();
            //displayAll();
            //showEmployeesOfDept("Army"); // unknown Dept Name gives Null point reference
            //showEmployeesOfDept("Training");
            showEmpWithDepts();


        }

        private static void insertEmployee()
        {
            //As EmpID is auto generated, we dont need to set it.
            var emp = new Employee //Employee of LINQ DBContext
            {
                EmpName = "Phaniraj",
                EmpAddress = "Bangalore",
                EmpSalary = 60000,
                ID = 1 //Assuming DeptId 1 exists in the DeptTable
            };
            var context = new EmpDBDataContext();
            context.Employees.InsertOnSubmit(emp); //InsertOnSubmit is used to add a new record to the Employees table.
            context.SubmitChanges(); //SubmitChanges is used to save the changes to the database.
        }

        private static void updateEmployee()
        {
            //create the Dbcontext.
            var context = new EmpDBDataContext();
            //find the matching record to updaate
            var rec = context.Employees.FirstOrDefault(emp => emp.EmpId == 1); //Assuming EmpId 1 exists in the Employees table.
            //update the values
            rec.EmpName = "Saili Patil";
            rec.EmpSalary = 78000;
            //save the changes.
            context.SubmitChanges(); //SubmitChanges is used to save the changes to the database.
        }

        private static void displayAll()
        {
            var context = new EmpDBDataContext();
            //var records = from emp in context.Employees
            //              select emp; //Select * from Employee
            //foreach(var emp in records)
            //{
            //    Console.WriteLine(emp.EmpName);
            //}

            var depts = from dept in context.DeptTables
                        select dept; //Select * from DeptTable
            foreach (var item in depts)
            {
                Console.Write(item.DeptId + " "  );
                Console.WriteLine(item.DeptName);
            }


        }

        private static void showEmployeesOfDept(string v)
        {
            var context = new EmpDBDataContext();
            var records = context.DeptTables.FirstOrDefault(dept => dept.DeptName == v).Employees;
            foreach (var rec in records)
            {
                Console.WriteLine(rec.EmpName);
            }
        }

        private static void showEmpWithDepts()
        {
            //create context
            var context = new EmpDBDataContext();
            //query the Employees table and join with DeptTable to get the department name.
            var records = from emp in context.Employees
                          join dept in context.DeptTables
                          on emp.ID equals dept.DeptId //Join condition
                          select new
                          {
                              Name = emp.EmpName,
                              Dept = dept.DeptName,
                              Salary = emp.EmpSalary
                          };
            //display the data
            foreach (var item in records)
            {
                Console.WriteLine(item);
            }
        }
    }
}

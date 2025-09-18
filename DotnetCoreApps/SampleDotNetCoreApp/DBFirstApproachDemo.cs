using SampleDotNetCoreApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SampleDotNetCoreApp
{
    //Scaffold-DBContext "Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = FNFTraining; Integrated Security = True; Encrypt=False;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -Tables "Employee","DeptTable"
    internal class DBFirstApproachDemo
    {
        static void Main(string[] args)
        {
                try
               {
                    var context = new FnftrainingContext();
                    context.Employees.Add(new Employee
                   {
                       Id=3,
                       EmpAddress = "Mumbai",
                       EmpSalary = 55000,
                       EmpName = "Sanket"
                    });
                   context.SaveChanges();
                   Console.WriteLine("Inserted Successfully");
                }
                catch (Exception ex) { 

                    Console.WriteLine(ex.Message);
                   Console.WriteLine(ex.InnerException?.Message);
              }
            }
        }
    }


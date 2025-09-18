using DotNetCorelib.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetCorelib.DTOs
{
    //Todo: Create Db first approach component with the interface for Employee Object
    public class EmployeeDTO
    {
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Employee name is mandatory")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Employee address is mandatory")]
        public string EmpAddress { get; set; }

        [Required(ErrorMessage = "Employee salary is mandatory")]
        public double EmpSalary { get; set; }

        public int ID { get; set; }

        // Add this line
        public int DeptId { get; set; }

        // Optional: Include department name if needed
        public string DeptName { get; set; }
    }

    //public class DeptDto
    //    {
    //        public int DeptId { get; set; }
    //        [Required(ErrorMessage = "Department name is mandatory")]
    //        public string DeptName { get; set; }

    //    }
    public interface IEmployee
        {
            void AddEmployee(EmployeeDTO Employee);
            IEnumerable<EmployeeDTO> GetAllEmployees();
            EmployeeDTO GetEmployeeById(int EmpId);
            void UpdateEmployee(EmployeeDTO Employee);
            void DeleteEmployee(int EmpId);
        }

        public class EmployeeRepo : IEmployee
        {
            private readonly Data.FnftrainingContext _context;

            public EmployeeRepo(Data.FnftrainingContext context)
            {
                _context = context;
            }

            //Implement CRUD operations
            public void AddEmployee(EmployeeDTO employee)
            {
                _context.Employees.Add(new Employee
                {
                    EmpName = employee.EmpName,
                    EmpAddress = employee.EmpAddress,
                    EmpSalary = (decimal)employee.EmpSalary,
                    Id = (int)employee.ID
                });
                _context.SaveChanges();
            }

            public void DeleteEmployee(int EmpId)
            {
                var employee = _context.Employees.Find(EmpId);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                }
            }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var data = _context.Employees
                .Include(e => e.Dept)
                .Select(e => new EmployeeDTO
                {
                    EmpId = e.EmpId,
                    EmpName = e.EmpName,
                    EmpAddress = e.EmpAddress,
                    EmpSalary = (double)e.EmpSalary,
                    ID = e.Id.HasValue ? e.Id.Value : 0,
                    DeptId = e.Dept != null ? e.Dept.DeptId : 0,
                    DeptName = e.Dept != null ? e.Dept.DeptName : "N/A"
                }).ToList();

            return data;
        }




        public EmployeeDTO GetEmployeeById(int EmpId)
        {
            var employee = _context.Employees
                .Include(e => e.Dept)
                .FirstOrDefault(e => e.Id == EmpId);

            if (employee == null) return null;

            return new EmployeeDTO
            {
                EmpId = employee.EmpId,
                EmpName = employee.EmpName,
                EmpAddress = employee.EmpAddress,
                EmpSalary = (double)employee.EmpSalary,
                ID = (int)employee.Id,
                DeptId = employee.Dept != null ? employee.Dept.DeptId : 0,
                DeptName = employee.Dept != null ? employee.Dept.DeptName : "N/A"
            };
        }

        public void UpdateEmployee(EmployeeDTO employee)
            {
                var emp = _context.Employees.Find(employee.EmpId);
                if (emp != null)
                {
                    emp.EmpName = employee.EmpName;
                    emp.EmpAddress = employee.EmpAddress;
                    emp.EmpSalary = (decimal)employee.EmpSalary;
                    emp.Id = employee.ID;
                    _context.SaveChanges();
                }
            }
        }
 }


//   Scaffold-DBContext "Data Source=FNFIDVPRE22648;Initial Catalog=FNFTraining;Integrated Security=True;Encrypt=False;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -Tables "Employee", "DeptTable"







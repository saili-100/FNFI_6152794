using Microsoft.AspNetCore.Mvc;
using SampleMvcCoreApp.Models;

namespace SampleMvcCoreApp.Controllers
{
    public class FirstExampleController : Controller
    {
        
        public string Welcome()
        {
            return "Welcome to MVC";
        }
        public Employee GetEmployee()
        {
            Employee emp = new Employee()
            {
                EmpId = 101,
                EmpName = "John Doe",
                EmpAddress = "123 Main St, Anytown, USA",
                EmpSalary = 60000.00M,
                DeptId = 10
            };
            return emp;
        }
        public ViewResult Display()
        {
            var model = GetEmployee();
            return View(model);
        }
    }
}


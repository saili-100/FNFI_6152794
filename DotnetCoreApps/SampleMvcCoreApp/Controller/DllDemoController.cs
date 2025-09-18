using DotNetCorelib.DTOs;
using Microsoft.AspNetCore.Mvc;
using static DotNetCorelib.DTOs.EmployeeDTO;

namespace SampleMvcCoreApp.Controllers
{
    public class DllDemoController : Controller
    {
        private IEmployee _employeeRepo;
        public DllDemoController(IEmployee employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

         public IActionResult Index()
        {
            var records = _employeeRepo.GetAllEmployees();
            return View("AllEmployees",records);
        }
    }
}

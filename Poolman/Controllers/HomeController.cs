using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Poolman.Interface;
using Poolman.Models;
using System.Diagnostics;

namespace Poolman.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployee _ObjEmployee;

        public HomeController(ILogger<HomeController> logger, IEmployee ObjEmpployee)
        {
            _logger = logger;
            this._ObjEmployee = ObjEmpployee;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllEmployee()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            this._ObjEmployee.SaveEmployeeData(employee);
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

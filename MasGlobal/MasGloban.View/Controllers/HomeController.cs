using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MasGloban.View.Models;
using MasGloban.View.Services.Employee.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using MasGlobal.Common.Model;
using System.Linq;

namespace MasGloban.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string employeeId)
        {

            List<EmployeeDTO> employees = await _employeeService.GetEmployees();
            if (string.IsNullOrEmpty(employeeId))
            {
                return View(employees);
            }
            else
            {
                int id;
                if (int.TryParse(employeeId, out id))
                    return View(employees.Where(r => r.Id == id));
                else
                    return View(employees);
            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

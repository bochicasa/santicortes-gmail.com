using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasGlobal.Business.Service.Employee.Interfaces;
using MasGlobal.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MasGlobal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        readonly ILogger<EmployeeController> _log;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> log)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAll()
        {
            IEnumerable<EmployeeDTO> employees = await _employeeService.GetAll();
            return Ok(employees);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            EmployeeDTO employee = await _employeeService.GetById(id);
            return Ok(employee);
        }
    }
}

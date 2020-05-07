using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using RocketElevatorApi.Models;
using System;


namespace RocketElevatorApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly RocketElevatorContext _context;
        public EmployeeController(RocketElevatorContext context)
        {
            _context = context;
        }

        // To see all the employees                            https://localhost:5001/api/employee/all
        // GET: api/employees/all
        [HttpGet("all")]
        public IEnumerable<Employee> GetEmployee()
        {
            return _context.Employees;
        }

        // To get an intervention by email                               https://localhost:5001/api/employee/{email}
        // GET: api/employee/{email}  
        [HttpGet("{employee_email}")]
        public ActionResult<List<Employee>> FindEmployee_Email(string employee_email)
        {
            var email = _context.Employees.Where(t => t.email == employee_email).ToList();

            if (email.Count == 0)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
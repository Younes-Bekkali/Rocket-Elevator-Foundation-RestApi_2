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
        // GET: api/employee/all
        [HttpGet("all")]
        public IEnumerable<Employee> GetEmployee()
        {
            return _context.Employees;
        }

    }
}
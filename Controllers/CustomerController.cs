using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public CustomerController(RocketElevatorContext context)
        {
            _context = context;

        }

        // To see all customer                                          https://localhost:5001/api/customer
        // GET: api/customer/all           
        [HttpGet("all")]
        public IEnumerable<Customer> GetCustomers()
        {
            IQueryable<Customer> Customers =
            from leaad in _context.Customers

            select leaad;

            return Customers.ToList();

        }
        
    }
}

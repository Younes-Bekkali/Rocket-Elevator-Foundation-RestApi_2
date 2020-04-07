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
    public class LeadController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public LeadController(RocketElevatorContext context)
        {
            _context = context;

        }

        // To get full list of leads                                    https://localhost:5001/api/lead/all
        // GET: api/lead/all           
        [HttpGet("all")]
        public IEnumerable<Lead> GetLeads()
        {
            IQueryable<Lead> Leads =
            from leaad in _context.Leads
            select leaad;
            return Leads.ToList();

        }

        // Retrieving a list of Leads created in the last 30 days who have not yet become customers
        //                                                              https://localhost:5001/api/lead/notcustomers
        // GET: api/Lead         
         [HttpGet("notcustomers")]
         public IEnumerable<Lead> GetLead()
         {
            IQueryable<Lead> notCustomers =
            from leaad in _context.Leads
            where leaad.created_at  >= System.DateTime.Now.AddDays(-30)
            select leaad;
            return notCustomers.ToList();
         }               
    }
}

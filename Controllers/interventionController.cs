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
    public class InterventionController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public InterventionController(RocketElevatorContext context)
        {
            _context = context;

        }

        

        // Retriving the full interventions list                            https://localhost:5001/api/intervention/all
        // GET api/intervention/all :       
        [HttpGet ("all")]
        public ActionResult<List<Intervention>> GetAll() 
        {
            return _context.Interventions.ToList ();
        }

        //GET: Returns all fields of all Service 
        //Request records that do not have a start date and are in "Pending" status.
        //https://localhost:5001/api/intervention/PendingList
         [HttpGet("PendingList")]
        public IEnumerable<Intervention> GetInterventions() {
            IQueryable<Intervention> Interventions =
            from le in _context.Interventions
            where le.start_intervention == null && le.status == "Pending"
            select le;

            return Interventions.ToList();
        }

        

        // Retriving Status of a specific Intervention                      https://localhost:5001/api/intervention/1
        // GET: api/intervention/1          
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetTodoItem(long id)
        {
            var todoItemElev = await _context.Interventions.FindAsync(id);

            if (todoItemElev == null)
            {
                return NotFound();
            }

            return todoItemElev;
        }



        //PUT: Change the status of the intervention request to "InProgress" 
        //and add a start date and time (Timestamp).
        // https://localhost:5001/api/intervention/InProgress
         [HttpPut("InProgress/{id}")]
        public async Task<IActionResult> PutInProgress(long id, Intervention item) {
            _context.Entry(item).State = EntityState.Modified;

            if (id != item.id) {
                return BadRequest();
            }
            if (item.status != "InProgress" ){
            item.start_intervention = System.DateTime.Now;
            item.status = "InProgress";
            item.end_intervention = null;
            await _context.SaveChangesAsync();
            return NoContent();
            } else {
            return BadRequest();
            }

        }


        // PUT: Change the status of the request for action to "Completed"
        // and add an end date and time (Timestamp).
        //https://localhost:5001/api/intervention/Completed
        [HttpPut("Completed/{id}")]
        public async Task<IActionResult> PutCompleted(long id, Intervention item) {
            _context.Entry(item).State = EntityState.Modified;

            if (id != item.id) {
                return BadRequest();
            }
            if (item.status != "Completed" ){
                item.end_intervention = System.DateTime.Now;
                item.start_intervention = System.DateTime.Now;
                item.status = "Completed";
                await _context.SaveChangesAsync();
                return NoContent();
            
            } else {
                 return BadRequest();
            }

        }

        
        // Bonus: Helpful sometimes
        // PUT: Change the status of the request for action to "Pending"
        // and set the start and  end date to null (Timestamp).
        //https://localhost:5001/api/intervention/Pending
        [HttpPut("Pending/{id}")]
        public async Task<IActionResult> PutPending(long id, Intervention item) {
            _context.Entry(item).State = EntityState.Modified;

            if (id != item.id) {
                return BadRequest();
            }
            if (item.status == "pending" || item.status == "inprogress" || item.status == "completed"){
                item.start_intervention = null;
                item.end_intervention = null;
                item.status = "Pending";
                await _context.SaveChangesAsync();
                return NoContent();
            
            } else {
                 return BadRequest();
            }

        }

        
        


        


        
        


    }
}
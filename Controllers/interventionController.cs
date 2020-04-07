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

        

        // Retriving the full interventions list                            https://localhost:5001/api/elevator/all
        // GET api/intervention/all :       
        [HttpGet ("all")]
        public ActionResult<List<Intervention>> GetAll() 
        {
            return _context.Interventions.ToList ();
        }

        //GET: Returns all fields of all Service 
        //Request records that do not have a start date and are in "Pending" status.
        //https://localhost:5001/api/intervention/notStartIntervention
         [HttpGet("notStartIntervention")]
        public IEnumerable<Intervention> GetInterventions() {
            IQueryable<Intervention> Interventions =
            from le in _context.Interventions
            where le.start_intervention == null && le.status == "pending"
            select le;

            return Interventions.ToList();
        }

        //PUT: Change the status of the intervention request 
        //to "InProgress" and add a start date and time (Timestamp).

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

        
         [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Intervention item) {
            _context.Entry(item).State = EntityState.Modified;

            if (id != item.id) {
                return BadRequest();
            }
            if (item.status == "InProgress"){
            item.start_intervention = System.DateTime.Now;
            item.end_intervention = null;
            await _context.SaveChangesAsync();
            return NoContent();
            }
            if (item.status == "Completed"){
            item.end_intervention = System.DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
            }
            if (item.status == "Pending"){
            item.start_intervention = null;
            item.end_intervention = null;

            await _context.SaveChangesAsync();
            return NoContent();
            }
            else
                {
                return BadRequest();
                }

        }
        

        // Changing Status of a specific Elevator                       https://localhost:5001/api/elevator/4   
        // PUT: api/elevator/4             
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutTodoItem(long id, Intervention article)
        // {
        //     if (id != article.id)
        //     {
        //         return BadRequest();
        //     }
        //     else if (article.status == "active" || article.status == "inactive" || article.status == "intervention" )
        //     {
        //         _context.Entry(article).State = EntityState.Modified;
        //         await _context.SaveChangesAsync();
        //         return Content("The status of the Elevator Id: " + article.id + " as been changed satisfactorily to: " + article.status);
        //     }

        //     return Content("Invalid value entered. The valid status are: active, inactive, intervention!");
        // }


    }
}
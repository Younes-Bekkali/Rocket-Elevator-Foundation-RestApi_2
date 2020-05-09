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
    public class ElevatorController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public ElevatorController(RocketElevatorContext context)
        {
            _context = context;

        }

        // Retriving the full elevators list                            https://localhost:5001/api/elevator/all
        // GET api/elevator/all :       
        [HttpGet("all")]
        public ActionResult<List<Elevator>> GetAll()
        {
            return _context.Elevators.ToList();
        }

        // Retriving Status of All the Elevators not active             https://localhost:5001/api/elevator/notinoperation
        // GET: api/elevator/notinoperation            

        [HttpGet("notinoperation")]
        public IEnumerable<Elevator> GetElevators()
        {
            IQueryable<Elevator> Elevators = from list_elev in _context.Elevators
                                             where list_elev.status != "active"
                                             select list_elev;

            return Elevators.ToList();
        }


        // Retriving Status of All the Elevators active             https://localhost:5001/api/elevator/active
        // GET: api/elevator/notinoperation            

        [HttpGet("active")]
        public IEnumerable<Elevator> GetActiveElevators()
        {
            IQueryable<Elevator> Elevators = from list_elev in _context.Elevators
                                             where list_elev.status == "active"
                                             select list_elev;

            return Elevators.ToList();
        }



        // Retriving Status of a specific Elevator                      https://localhost:5001/api/elevator/4
        // GET: api/elevator/4            
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetTodoItem(long id)
        {
            var todoItemElev = await _context.Elevators.FindAsync(id);

            if (todoItemElev == null)
            {
                return NotFound();
            }

            return todoItemElev;
        }

        // Changing Status of a specific Elevator                       https://localhost:5001/api/elevator/4   
        // PUT: api/elevator/4             
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Elevator article)
        {
            if (id != article.id)
            {
                return BadRequest();
            }
            else if (article.status == "active" || article.status == "inactive" || article.status == "intervention")
            {
                _context.Entry(article).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Content("The status of the Elevator Id: " + article.id + " as been changed satisfactorily to: " + article.status);
            }

            return Content("Invalid value entered. The valid status are: active, inactive, intervention!");
        }


        // PUT: api/elevator/{id}/inactive                     https://localhost:5001/api/elevator/2/inactive
        //Change the status of the elevator to inactive
        [HttpPut("{id}/inactive")]
        public async Task<ActionResult<Elevator>> UpdateElevatortoInactive([FromRoute] long id)
        {
            var myElevator = await this._context.Elevators.FindAsync(id);
            if (myElevator == null)
            {
                return NotFound();
            }
            else
            {
                myElevator.status = "inactive";

            }
            this._context.Elevators.Update(myElevator);
            await this._context.SaveChangesAsync();

            return Content("The status of the elevator ID: " + myElevator.id +
            " has been changed to: " + myElevator.status);
        }

        // PUT: api/elevator/{id}/active                     https://localhost:5001/api/elevator/2/active
        //Change the status of the elevator to active
        [HttpPut("{id}/active")]
        public async Task<ActionResult<Elevator>> UpdateElevatorToActive([FromRoute] long id)
        {
            var myElevator = await this._context.Elevators.FindAsync(id);
            if (myElevator == null)
            {
                return NotFound();
            }
            else
            {
                myElevator.status = "active";

            }
            this._context.Elevators.Update(myElevator);
            await this._context.SaveChangesAsync();

            return Content("The status of the elevator ID: " + myElevator.id +
            " has been changed to: " + myElevator.status);
        }


    }
}
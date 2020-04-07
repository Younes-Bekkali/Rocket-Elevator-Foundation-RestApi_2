using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers
{
    [Route("api/battery")]
    [ApiController]
    public class BatteryController : ControllerBase
    {
        private readonly RocketElevatorContext _context;
        public BatteryController(RocketElevatorContext context)
        {
            _context = context;
        }

        // To see all the batteries availables                  https://localhost:5001/api/battery/all
        // GET: api/battery/all
        [HttpGet("all")]
        public IEnumerable<Battery> GetBattery()
        {
            return _context.Batteries;
        }

        // To get a battery by id                               https://localhost:5001/api/battery/10 
        // GET: api/battery/(id)  
        [HttpGet("{id}")]
        public List<Battery> FindBatteryByID(long ID)
        {
            var battery = _context.Batteries.Where (bat => bat.id == ID).ToList();
            return battery;
        }

        //To get all the active batteries                       https://localhost:5001/api/battery/active
        // GET: api/battery/active  
        [HttpGet("active")]
        public List<Battery> GetBattery(string active)
        {
            var battery = _context.Batteries.Where (battery => battery.status == "active").ToList();
            return battery;
        }

        //To get all the inactive batteries                     https://localhost:5001/api/battery/inactive
        // GET: api/Battery/inactive  
        [HttpGet("inactive")]
        public List<Battery> FindBattery(string inactive)
        {
            var battery = _context.Batteries.Where (battery => battery.status == "inactive").ToList();
            return battery;
        }

        // To update a battery                                  https://localhost:5001/api/battery/10
        // PUT: api/battery/(id) 
        [HttpPut("{id}")]
        public async Task<ActionResult<Battery>> PostBattery(long ID, Battery battery)
        {
            if (ID != battery.id)
            {
                return null;
            } 
            _context.Entry(battery).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ID != battery.id)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Content("The status of the Battery Id: " + battery.id + " as been changed satisfactorily to: " + battery.status);
        }
    }
}
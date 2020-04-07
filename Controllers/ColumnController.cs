using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers
{
    [Route("api/Column")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public ColumnController(RocketElevatorContext context)
        {
            _context = context;

        }

        //To see all columns availables                          https://localhost:5001/api/column/all
        // GET: api/column/all 
        [HttpGet("all")]
        public IEnumerable<Column> GetColumn()
        {
            return _context.Columns;
        }

        // To get column by id                                  https://localhost:5001/api/column/10 
        // GET: api/Column/(id)  
        [HttpGet("{id}")]
        public List<Column> FindColumnByID(long ID)
        {
            var column = _context.Columns.Where (bat => bat.id == ID).ToList();
            return column;
        }

        // To get all the active columns                        https://localhost:5001/api/column/active
        // GET: api/column/active  
        [HttpGet("active")]
        public List<Column> GetColumn(string active)
        {
            var column = _context.Columns.Where (column=> column.status == "active").ToList();
            return column;
        }

        // To get all the inactive columns                      https://localhost:5001/api/column/inactive
        // GET: api/Column/inactive  
        [HttpGet("inactive")]
        public List<Column> FindColumn(string inactive)
        {
            var column = _context.Columns.Where (column => column.status == "inactive").ToList();
            return column;
        }

        // To update Column status                               https://localhost:5001/api/Column/(id)
        // PUT: api/Column/(id) 
        [HttpPut("{id}")]
        public async Task<ActionResult<Column>> PostBattery(long ID, Column column)
        {
            if (ID != column.id)
            {
                return null;
            }
            _context.Entry(column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ID != column.id)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content("The status of the Column Id: " + column.id + " as been changed satisfactorily to: " + column.status);

        }
     
    }
}
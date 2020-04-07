using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySql.Data.MySqlClient;

using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase {
        private readonly RocketElevatorContext _context;

        public BuildingController(RocketElevatorContext context) {
            _context = context;
        }
         
        // Retriving all  building list                                 https://localhost:5001/api/building/all 
        // GET: api/building/all         
        [HttpGet("all")]
        public ActionResult<List<Building>> GetAll()        
        {
            return _context.Buildings.ToList ();
        }

        // Retriving Status of a specific Building                      https://localhost:5001/api/building/55
        // GET: api/building/55            
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetTodoItem(long id)
        {
            var todoItemBuild = await _context.Buildings.FindAsync(id);

            if (todoItemBuild == null)
            {
                return NotFound();
            }

            return todoItemBuild;
        }

        // Retrieving a list of Buildings requiring intervention        https://localhost:5001/api/building/intervention
        // GET: api/building/intervention             
        [HttpGet("intervention")]
        public IEnumerable<Building> GetBuildingsIntervention() 
        {
            IQueryable<Building> Building = from build in _context.Buildings
                join batte in _context.Batteries on build.id equals batte.building_id
                join colum in _context.Columns on batte.id equals colum.battery_id
                join eleva in _context.Elevators on colum.id equals eleva.column_id
                where batte.status == "intervention" || colum.status == "intervention" || eleva.status == "intervention"
                select build;
            return Building.ToList();
        }
    }
}
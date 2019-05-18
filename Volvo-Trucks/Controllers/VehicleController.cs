using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volvo_Trucks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volvo_Trucks.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly VehicleContext _context;
        public VehicleController(VehicleContext context)
        {
            _context = context;
        }
        
        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public IActionResult GetVehicle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpGet]
        public IEnumerable<Vehicle> GetVehicle()
        {
            return _context.Vehicles;
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public IActionResult PutVehicle([FromRoute] int id, [FromBody] Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        [HttpPost]
        public IActionResult PostVehicle([FromBody] Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vehicles.Add(vehicle);
            _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }


        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            _context.SaveChangesAsync();

            return Ok(vehicle);
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}

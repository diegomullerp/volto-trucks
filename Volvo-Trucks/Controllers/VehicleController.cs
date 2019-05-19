using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volvo_Trucks.Models;
using Volvo_Trucks.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volvo_Trucks.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly VehicleContext _context;
        private VehicleService _vehicleService;
        public VehicleController(VehicleContext context)
        {
            _context = context;
            _vehicleService = new VehicleService(_context);

        }
        
        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public IActionResult GetVehicle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vehicle = _vehicleService.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpGet]
        public IEnumerable<Vehicle> GetVehicle()
        {
            return _vehicleService.GetAll();
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

            try
            {
                _vehicleService.Update(vehicle, id);
            }
            catch (Exception ex)
            {
                throw (ex);
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

            _vehicleService.Save(vehicle);

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


            _vehicleService.Delete(id);

            return Ok();
        }

        
    }
}

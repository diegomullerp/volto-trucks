using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volvo_Trucks.Models
{
    public class VehicleContext: DbContext
    {
        public VehicleContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}

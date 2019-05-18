using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volvo_Trucks.Models
{
    public class Vehicle
    {
        enum VehicleModel
        {
            FH = 1,
            FM = 2
        }
        [Key]
        public int Id { get; set; }
        public string FabricationYear { get; set; }
        public int ModelYear { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}

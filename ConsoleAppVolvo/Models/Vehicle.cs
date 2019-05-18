using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Vehicle
    {
        enum VehicleModel
        {
            FH = 1,
            FM = 2
        }

        public int Id { get; set; }
        public string FabricationYear { get; set; }
        public int ModelYear { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Model { get; set; }


        public Vehicle()
        {

        }
        public Vehicle(int chassisNumber)
        {
            Vehicle vehicle = VehicleService.GetVehicleByChassisNumber(chassisNumber).Result;
            this.Id = vehicle.Id;
            this.FabricationYear = vehicle.FabricationYear;
            this.ModelYear = vehicle.ModelYear;
            this.Name = vehicle.Name;
            this.Color = vehicle.Color;
        }
        public void Save()
        {
            try
            {
                Validations();
                VehicleService vehicleService = new VehicleService();
                vehicleService.SaveVehicle(this);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public List<Vehicle> GetAll()
        {
            try
            {
                VehicleService vehicleService = new VehicleService();
                return vehicleService.GetAll();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            try
            {
                VehicleService vehicleService = new VehicleService();
                vehicleService.Delete(this);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()
        {
            try
            {
                VehicleService vehicleService = new VehicleService();
                vehicleService.EditVehicle(this);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Validations()
        {
           
        }
    }
}

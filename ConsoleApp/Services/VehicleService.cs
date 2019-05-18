using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class VehicleService
    {
        public void SaveVehicle(Vehicle vehicle)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri("http://localhost:58496/");
                var response = client.PostAsJsonAsync("api/vehicles", vehicle).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                }


            }
        }

        public void EditVehicle(Vehicle vehicle)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri("http://localhost:58496/");
                var response = client.PutAsJsonAsync("api/vehicles/" + vehicle.Id.ToString(), vehicle).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                }


            }
        }

        public List<Vehicle> GetAll()
        {
            try
            {
                List<Vehicle> printers = new List<Vehicle>();
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString("http://localhost:58496/api/vehicles");
                    printers = JsonConvert.DeserializeObject<List<Vehicle>>(result);
                }

                return printers;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not retrieve list of Vehicles, please get in contact with Support IT");
            }
        }

        public void Delete(Vehicle vehicle)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri("http://localhost:58496/");
                var response = client.DeleteAsync("api/vehicles/" + vehicle.ChassisNumber).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        public static async Task<Vehicle> GetVehicleByChassisNumber(int chassisNumber)
        {
            Vehicle vehicle = new Vehicle();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:58496/" + chassisNumber.ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/vehicles/" + chassisNumber.ToString());
                if (response.IsSuccessStatusCode)
                {  //GET
                    vehicle = await response.Content.ReadAsAsync<Vehicle>();
                }
            }
            return vehicle;
        }
    }
}

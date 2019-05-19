using ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp.Services
{
    public class VehicleService
    {
        //  public object JsonConvert { get; private set; }
        private string APIUrl = ConfigurationManager.AppSettings.Get("API");
        public void SaveVehicle(Vehicle vehicle)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(APIUrl);
                var response = client.PostAsJsonAsync("api/vehicle", vehicle).Result;
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

                client.BaseAddress = new Uri(APIUrl);
                var response = client.PutAsJsonAsync("api/vehicle/" + vehicle.Id.ToString(), vehicle).Result;
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
                List<Vehicle> trucks = new List<Vehicle>();
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(APIUrl + "/api/vehicle");
                    trucks = JsonConvert.DeserializeObject<List<Vehicle>>(result);
                }

                return trucks;
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

                client.BaseAddress = new Uri(APIUrl);
                var response = client.DeleteAsync("api/vehicle/" + vehicle.Id).Result;
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
                client.BaseAddress = new System.Uri("http://localhost:49983/" + chassisNumber.ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/vehicle/" + chassisNumber.ToString());
                if (response.IsSuccessStatusCode)
                {  //GET
                    vehicle = await response.Content.ReadAsAsync<Vehicle>();
                }
            }
            return vehicle;
        }
    }
}

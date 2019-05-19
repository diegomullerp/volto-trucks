using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool notExit = true;
            while (notExit)
            {
                Console.Clear();
                Console.WriteLine("-----------VOLVO-TRUCKS--------------------");
                Console.WriteLine("-----------Menu--------------------");
                Console.WriteLine();

                Console.WriteLine("1 - Insert New Truck");
                Console.WriteLine();
                Console.WriteLine("2 - Edit a existing Truck");
                Console.WriteLine();
                Console.WriteLine("3 - Delete a existing Truck");
                Console.WriteLine();
                Console.WriteLine("4 - List all Trucks");
                Console.WriteLine();
                Console.WriteLine("5 - Find Vehicle by id");
                Console.WriteLine();
                Console.WriteLine("6 - Exit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Please type your option: ");

                string key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        New(); break;
                    case "2":
                        Edit(); break;
                    case "3":
                        Delete(); break;
                    case "4":
                        List(); break;
                    case "5":
                        FindById(); break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Do you want to exit the application (Y/N)?");
                        string exitConfirmation = Console.ReadLine();
                        if (exitConfirmation.ToUpper() == "Y")
                            notExit = false;
                        break;
                    default:
                        break;
                }
            }
        }

        static void New()
        {
            try
            {
                Vehicle vehicle = new Vehicle();
                Console.Clear();
                Console.WriteLine("Insert New Vehicle");
                Console.WriteLine();
                Console.WriteLine("Truck Model: (1 - FH, 2 - FM) ");
                int model;
                if (int.TryParse(Console.ReadLine(), out model))
                    vehicle.Model = model;


                Console.WriteLine("Fabrication Year: ");
                int fabricationYear;
                if (int.TryParse(Console.ReadLine(), out fabricationYear))
                    vehicle.FabricationYear = fabricationYear.ToString();

                Console.WriteLine("Model Year: ");
                int modelYear;
                if (int.TryParse(Console.ReadLine(), out modelYear))
                    vehicle.ModelYear = modelYear;

                Console.WriteLine("Truck Name: ");
                vehicle.Name = Console.ReadLine();

                Console.WriteLine("Truck Color: ");
                vehicle.Color = Console.ReadLine();
                
                vehicle.Save();
                Console.WriteLine("Truck was sucessfully saved!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }
        }
        static void Edit()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Edit an existing Truck");
                Console.WriteLine();

                Console.WriteLine("Please type the Id Number of the Vehicle: ");

                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    Vehicle vehicle = new Vehicle(id);
                    if (vehicle.Id > 0)
                    {
                        Console.WriteLine("Truck Model: (1 - FH, 2 - FM) ");
                        int model;
                        if (int.TryParse(Console.ReadLine(), out model))
                            vehicle.Model = model;


                        Console.WriteLine("Fabrication Year: ");
                        int fabricationYear;
                        if (int.TryParse(Console.ReadLine(), out fabricationYear))
                            vehicle.FabricationYear = fabricationYear.ToString();

                        Console.WriteLine("Model Year: ");
                        int modelYear;
                        if (int.TryParse(Console.ReadLine(), out modelYear))
                            vehicle.ModelYear = modelYear;

                        Console.WriteLine("Truck Name: ");
                        vehicle.Name = Console.ReadLine();

                        Console.WriteLine("Truck Color: ");
                        vehicle.Color = Console.ReadLine();

                        vehicle.Edit();
                        Console.WriteLine("Truck was sucessfully updated!");
                    }
                    else
                        Console.WriteLine("Truck not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to Edit Truck, please get in contact with support IT.");
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }

        }
        static void Delete()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Delete an existing Truck");
                Console.WriteLine();
                Console.WriteLine("Please type the Truck ID: ");
                Vehicle vehicle = new Vehicle();
                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                    vehicle.Id = id;

                vehicle.Id = id;
                vehicle.Delete();
                Console.WriteLine("Truck was deleted sucessfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to Delete Truck, please get in contact with support IT.");
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }
        }
        static void List()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("List of Trucks");
                Console.WriteLine();
                List<Vehicle> vehicles = new Vehicle().GetAll();

                foreach (Vehicle vehicle in vehicles)
                {
                    Console.WriteLine(" ID: " + vehicle.Id + " ｜ Name: " + vehicle.Name + " ｜ Fabrication Year: " + vehicle.FabricationYear + " ｜ Model Year: " + vehicle.ModelYear + " ｜ Model: " + (VehicleModel)vehicle.Model + " ｜ Color: " + vehicle.Color);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to List Trucks, please get in contact with support IT.");
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }
        }
        static void FindById()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Find Truck");
                Console.WriteLine();
                Console.WriteLine("Please type the Id of the Truck: ");

                int chassisNumber;
                if (int.TryParse(Console.ReadLine(), out chassisNumber))
                {
                    Vehicle vehicle = new Vehicle(chassisNumber);
                    if (vehicle.Id > 0)
                    {
                        Console.WriteLine("Truck found!");
                        Console.WriteLine(" ID: " + vehicle.Id + " ｜ Name: " + vehicle.Name + " ｜ Fabrication Year: " + vehicle.FabricationYear + " ｜ Model Year: " + vehicle.ModelYear + " ｜ Model: " + (VehicleModel)vehicle.Model + " ｜ Color: " + vehicle.Color);
                    }
                    else
                        Console.WriteLine("Truck not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to Find Truck, please get in contact with support IT.");
            }
            finally
            {
                Console.Write("Press any key to go back to menu");
                Console.ReadLine();
            }
        }

        enum VehicleModel
        {
            FH = 1,
            FM = 2
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VehicleInventoryProject.Interface;

namespace VehicleInventoryProject
{
    internal class VehicleInventory : IVehicleInventory
    {

        private List<IVehicle> inventory;

        public VehicleInventory()
        {
            inventory = new List<IVehicle>();
        }



        public void AddVehicle()
        {
            Console.WriteLine("Enter vehicle type (car, truck or motorcycle)");
            string type = Console.ReadLine();
            Console.WriteLine("Enter vehicle make");
            string make = Console.ReadLine();
            Console.WriteLine("Enter model");
            string model = Console.ReadLine();
            Console.WriteLine("Enter year of production");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year) || year < 1886 || year > 3000 )
            {
                Console.WriteLine("Invalid year! Please enter valid year.");
            }
            Console.WriteLine("Enter price");
            double price;
            while (!double.TryParse(Console.ReadLine(),out price) || price <= 0)
            {
                Console.WriteLine("Invalid price! Enter a valid amount.");
            }
            Console.WriteLine("Enter vehicle license plate with 8 symbols without space.");
            string addPlate = Console.ReadLine();
            if (ValidatePlateNumber(addPlate) == false) 
            {
                Console.WriteLine("Invalid license plate pattern. Enter 8 symbols without space.");
            }
            else
            {
                inventory.Add(new Vehicle(make, model, year, price, addPlate));
                Console.WriteLine("Vehicle is added successfully.");
            }

        }

        private bool ValidatePlateNumber(string plateNumber)
        {
            plateNumber = plateNumber.Replace(" ", "");
            string expresion = @"^[A-Z0-9]{8}$";
            if (Regex.IsMatch(plateNumber, expresion))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveVehicle(Vehicle plate)
        {
            Console.WriteLine("Enter the licese plate to remove vehicle.");
            string removePlate = Console.ReadLine() ;
            IVehicle vehicle = inventory.FirstOrDefault(v => v.Plate == removePlate);
            if (vehicle != null)
            {
                inventory.Remove(vehicle);
                Console.WriteLine("Vehicle removed.");
            }
            else
            {
                Console.WriteLine("Vehicle not in inventory.");
            }
        }

        public void UpdateVehiclePrice(Vehicle plate)
        {
            Console.WriteLine("Enter the licese plate to update vehicle price.");
            string updatePlate = Console.ReadLine() ;
            IVehicle vehicle = inventory.FirstOrDefault(v => v.Plate ==  updatePlate);
            if (vehicle != null)
            {
                double newPrice;
                while (!double.TryParse(Console.ReadLine(), out newPrice) || newPrice <= 0)
                {
                    Console.WriteLine("Invalid price! Enter a valid amount.");
                    Console.WriteLine("Enter price.");
                }

                vehicle.Price = newPrice;
                Console.WriteLine("Vehicle price updated.");
            }
            else
            {
                Console.WriteLine("Vehicle not in inventory.");
            }
        }

        public void ViewAllVehicles()
        {
            if(inventory.Count > 0)
            {
                foreach (IVehicle vehicle in inventory)
                {
                    Console.WriteLine($"Make: {vehicle.Make}");
                    Console.WriteLine($"Model: {vehicle.Model}");
                    Console.WriteLine($"Year of manufacture: {vehicle.Year}");
                    Console.WriteLine($"Price: {vehicle.Price}");
                    Console.WriteLine($"License plate: {vehicle.Plate}");
                }
            }
            else
            {
                Console.WriteLine("Inventory is empty");
            }
        }

        public void ViewVehiclesByType()
        {
            Console.WriteLine("Enter type of vehicle you want to view ( car, truck or motorcycle )");
            string vehicleType = Console.ReadLine();

            List<IVehicle> vehicleByType = inventory.Where(v => GetVehicleType(v) == vehicleType).OrderBy(v  => v.Make).ThenBy(v => v.Model).ToList();

        }

        private string GetVehicleType(IVehicle vehicle)
        {
            if (vehicle is Car)
            {
                return "car";
            }
            else if (vehicle is Truck)
            {
                return "truck";
            }
            else if (vehicle is Motorcycle)
            {
                return "motorcycle";
            }
            else
            {
                return "Invalid type.";
            }
        }

        
    }
}

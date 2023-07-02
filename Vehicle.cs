using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventoryProject.Interface;

namespace VehicleInventoryProject
{
    public class Vehicle : IVehicle
    {
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Plate { get; set; }



        public Vehicle(string make, string model, int year, double price, string plate)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Price = price;
            this.Plate = plate;
        }

        public Vehicle()
        {
            
        }



    }
}

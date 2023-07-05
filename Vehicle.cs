
namespace VehicleInventoryProject
{
    public class Vehicle : IVehicle
    {
        private string type;
        private string make;
        private string model;
        private int year;
        private double price;
        private string plate;


        public string Type => type;
        public string Make => make;
        public string Model => model;
        public int Year => year;
        public string Plate => plate;

        public double Price
        {
            get => price;
            set => price = value;
        }

        public Vehicle(string make, string model, int year, double price, string plate)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
            this.plate = plate;
        }

        public Vehicle()
        {
            
        }



    }
}

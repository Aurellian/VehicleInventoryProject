using VehicleInventoryProject;
using VehicleInventoryProject.Interface;

namespace VehicleInventoryProjectTests
{
    public class VehicleInventoryTests
    {
        private Car car;
        private Truck truck;
        private Motorcycle motorcycle;
        VehicleInventory inventory = new VehicleInventory();


        [SetUp]
        public void Setup()
        {
            car = new Car("Toyota", "Verso", 2012, 12000, "CB7972PB");
            truck = new Truck("Iveco", "Eurostar", 2022, 20000, "CBTR11KK");
            motorcycle = new Motorcycle("Honda", "Rebel1100", 2000, 6000, "CT9999CT");
        }

        //[Test]
        //public void AddVehicleToInventory()
        //{
        //    car = new Car("Toyota", "Verso", 2012, 12000, "CB7972PB");

        //    inventory.AddVehicle(car);

        //}

        [Test]
        public void AddVehicleThrowExceptionIfYearIsInvalid()
        {
            car = new Car("Toyota", "Verso", 2012, 12000, "CB7972PB");

            Assert.Throws<InvalidOperationException>(() =>
            {
                inventory.AddVehicle();
            });
        }
    }
}
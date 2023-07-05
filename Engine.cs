
using VehicleInventoryProject;

public class Engine
{
    public static void Main()
    {
        VehicleInventory inventory = new VehicleInventory();

            Console.WriteLine("WELCOME TO ITSTEP VEHICLE INVENTORY");
            Console.WriteLine();

        while (true)
        {

            Console.WriteLine("Select option from menu.");
            Console.WriteLine("1. Add vehicle to inventory.");
            Console.WriteLine("2. Remove vehicle from inventory.");
            Console.WriteLine("3. Update vehicle price.");
            Console.WriteLine("4. View all vehicle in inventory.");
            Console.WriteLine("5. View vehicle by type.");
            Console.WriteLine("6. Exit.");

            string input = Console.ReadLine();

            if (input == "1")
            {
                inventory.AddVehicle();
            }
            else if (input == "2")
            {
                inventory.RemoveVehicle();
            }
            else if (input == "3")
            {
                inventory.UpdateVehiclePrice();
            }
            else if (input == "4") {
                inventory.ViewAllVehicles();
            }
            else if (input == "5")
            {
                inventory.ViewVehiclesByType();
            }
            else if (input == "6")
            {
                Console.WriteLine("Exiting the program...");
                for (int i = 5; i >=1; i--)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
                
                return;
            }
            else
            {
                Console.WriteLine("Invalid comand!");
                Console.WriteLine();
            }
        }
    }
}

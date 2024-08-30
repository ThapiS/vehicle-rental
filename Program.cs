using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT1_LesediMmathapeloSedibe_PRG271
{
    //public interface IRentable
    //{
    //    void Rent(); //Method to rent
    //    void Return(); //Method to return
    //}

    //Base class for rentable vehicle
    public class Vehicle : IRentable
    {
        public string Identifier { get; set; }
        public bool IsRented { get; set; }

        public event EventHandler OnVehicleRented;
        public event EventHandler OnVehicleReturned;

        protected virtual void TriggerVehicleRentedEvent()
        {
            OnVehicleRented?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void TriggerVehicleReturnedEvent()
        {
            OnVehicleReturned?.Invoke(this, EventArgs.Empty);
        }

        //Method for getting info about the car
        public virtual string GetDetails()
        {
            return "Vehicle details";
        }

        public void Rent()
        {
            if (IsRented)
            {
                Console.WriteLine("Vehicle is already rented.");
                return;
                Console.ReadKey();
            }

            IsRented = true;
            Console.WriteLine("Vehicle is being rented...");
            TriggerVehicleRentedEvent();
        }

        public void Return()
        {
            if (!IsRented)
            {
                Console.WriteLine("Vehicle is not currently rented.");
                return;
            }

            IsRented = false;
            Console.WriteLine("Vehicle is being returned...");
            TriggerVehicleReturnedEvent();
        }
    }


    //Derived class
    public class Car : Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string GetDetails()
        {
            return $"Car Details: Make: {Make}, Model: {Model}, Year: {Year}, Identifier: {Identifier}";
        }
    }


    //Derived class
    public class Motorbike : Vehicle
    {
        public string Brand { get; set; }
        public int EngineCapacity { get; set; }

        public override string GetDetails()
        {
            return $"Motorbike Details: Brand: {Brand}, Engine Capacity: {EngineCapacity}cc, Identifier: {Identifier}";
        }
    }

    public class VehicleManager
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            Console.WriteLine($"{vehicle.GetDetails()} has been added to the system.");
        }

        public void ViewAvailableVehicles()
        {
            Console.WriteLine("Available Vehicles:");
            foreach (var vehicle in vehicles)
            {
                if (!vehicle.IsRented)
                {
                    Console.WriteLine(vehicle.GetDetails());
                }
            }
        }

        public void RentVehicle(string identifier)
        {
            var vehicle = vehicles.Find(v => v.Identifier == identifier && !v.IsRented);
            if (vehicle != null)
            {
                vehicle.Rent();
            }
            else
            {
                Console.WriteLine("Vehicle not found or already rented.");
            }
        }

        public void ReturnVehicle(string identifier)
        {
            var vehicle = vehicles.Find(v => v.Identifier == identifier && v.IsRented);
            if (vehicle != null)
            {
                vehicle.Return();
            }
            else
            {
                Console.WriteLine("Vehicle not found or not rented.");
            }
        }
    }

    //Main class
    class Program
    {
        static void Main()
        {
            VehicleManager manager = new VehicleManager();

            while (true)
            {
                Console.WriteLine("\nVehicle Management System");
                Console.WriteLine("1. Add a new vehicle");
                Console.WriteLine("2. View all available vehicles");
                Console.WriteLine("3. Rent a vehicle");
                Console.WriteLine("4. Return a vehicle");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddVehicle(manager);
                        break;
                    case "2":
                        manager.ViewAvailableVehicles();
                        break;
                    case "3":
                        RentVehicle(manager);
                        break;
                    case "4":
                        ReturnVehicle(manager);
                        break;
                    case "5":
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        //Method to add vehicle
        static void AddVehicle(VehicleManager manager)
        {
            Console.WriteLine("Enter vehicle type (car/motorbike): ");
            string type = Console.ReadLine().ToLower();

            Console.Write("Enter vehicle identifier: ");
            string identifier = Console.ReadLine();

            if (type == "car")
            {
                Console.Write("Enter make: ");
                string make = Console.ReadLine();
                Console.Write("Enter model: ");
                string model = Console.ReadLine();
                Console.Write("Enter year: ");
                int year = int.Parse(Console.ReadLine());

                Car car = new Car { Identifier = identifier, Make = make, Model = model, Year = year };
                manager.AddVehicle(car);
            }
            else if (type == "motorbike")
            {
                Console.Write("Enter brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter engine capacity: ");
                int engineCapacity = int.Parse(Console.ReadLine());

                Motorbike bike = new Motorbike { Identifier = identifier, Brand = brand, EngineCapacity = engineCapacity };
                manager.AddVehicle(bike);
            }
            else
            {
                Console.WriteLine("Unknown vehicle type.");
            }
        }

        static void RentVehicle(VehicleManager manager)
        {
            Console.Write("Enter vehicle identifier to rent: ");
            string identifier = Console.ReadLine();
            manager.RentVehicle(identifier);
        }

        static void ReturnVehicle(VehicleManager manager)
        {
            Console.Write("Enter vehicle identifier to return: ");
            string identifier = Console.ReadLine();
            manager.ReturnVehicle(identifier);
        }
    }

}


using CT1_LesediMmathapeloSedibe_PRG271;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentingSystem
{
    public class Car : Vehicle, IRentable
    {
        public int NumberOfDoors { get; set; }

        //Parameterless constructor
        public Car()
        {

        }

        //Constructor
        public Car(string make, string model, int year, decimal rentalRatePerDay, bool isAvailable, int numberOfDoors)
            : base(make, model, year, rentalRatePerDay, isAvailable)
        {
            NumberOfDoors = numberOfDoors;
        }

        public override string GetDetails()
        {
            return $"{base.ToString()}, Doors: {NumberOfDoors}";
        }

        public virtual void Rent()
        {
            Console.WriteLine("Vehicle is being rented...");
            TriggerVehicleRentedEvent();
        }

        public virtual void Return()
        {
            Console.WriteLine("Vehicle is being returned...");
            TriggerVehicleReturnedEvent();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentingSystem
{
    public class Vehicle
    {

        //Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal RentalRatePerDay { get; set; }
        public bool IsAvailable { get; set; }


        //Trigger events
        public event EventHandler OnVehicleRented;
        public event EventHandler OnVehicleReturned;


        //Parameterless Constructor
        public Vehicle()
        {

        }

        //Constructor
        public Vehicle(string make, string model, int year, decimal rentalRatePerDay, bool isAvailable)
        {
            Make = make;
            Model = model;
            Year = year;
            RentalRatePerDay = rentalRatePerDay;
            IsAvailable = isAvailable;
        }


        //Method
        public virtual string GetDetails()
        {
            return $"{Year} {Make} {Model}, Rental Rate: {RentalRatePerDay:C}, Available: {IsAvailable}";
        }

        protected virtual void TriggerVehicleRentedEvent()
        {
            OnVehicleRented?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void TriggerVehicleReturnedEvent()
        {
            OnVehicleReturned?.Invoke(this, EventArgs.Empty);
        }
    }
}

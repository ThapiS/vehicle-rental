using CT1_LesediMmathapeloSedibe_PRG271;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentingSystem
{

    //Inheritence
    public class Motorbike : Vehicle, IRentable
    {
        public bool HasSidecar { get; set; }

        //Constructor
        public Motorbike(string make, string model, int year, decimal rentalRatePerDay, bool isAvailable, bool hasSidecar)
            : base(make, model, year, rentalRatePerDay, isAvailable)
        {
            HasSidecar = hasSidecar;
        }

        public override string GetDetails()
        {
            return $"{base.ToString()}, Has Sidecar: {HasSidecar}";
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

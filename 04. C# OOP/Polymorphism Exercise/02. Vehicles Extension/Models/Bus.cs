using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public const double FUEL_CONSUMPTION_INCREMENT = 0.0;
        public Bus(double fuelQuantity, 
            double fuelConsumption,
            double tankCapacity) :
            base(fuelQuantity, fuelConsumption, FUEL_CONSUMPTION_INCREMENT, tankCapacity)
        {

        }
    }
}

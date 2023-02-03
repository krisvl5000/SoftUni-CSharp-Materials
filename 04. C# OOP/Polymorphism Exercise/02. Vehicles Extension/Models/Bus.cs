using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, 
            double fuelConsumption, 
            double fuelConsumptionIncrement,
            double tankCapacity) : 
            base(fuelQuantity, fuelConsumption, fuelConsumptionIncrement, tankCapacity)
        {

        }
    }
}

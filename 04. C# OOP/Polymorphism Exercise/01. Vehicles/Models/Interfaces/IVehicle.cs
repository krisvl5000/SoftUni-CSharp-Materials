using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }

        string Drive(double distance);

        void Refuel(double liters);
    }
}

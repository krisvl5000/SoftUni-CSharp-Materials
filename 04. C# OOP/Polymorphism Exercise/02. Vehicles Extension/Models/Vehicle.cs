using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, 
            double fuelConsumption, 
            double fuelConsumptionIncrement,
            double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + fuelConsumptionIncrement;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get { return FuelQuantity; }

            private set
            {
                if (value > TankCapacity)
                {
                    FuelQuantity = 0;
                }

                FuelQuantity = value;
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity {get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;

            if (neededFuel > FuelQuantity)
            {
                throw new InsufficientFuelException(String
                    .Format(ExceptionMessages
                    .INSUFFICIENT_FUEL_EXCEPTION_MESSAGE, GetType().Name));
            }

            FuelQuantity -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters > TankCapacity)
            {
                throw new TooMuchFuelException
                    (String.Format(ExceptionMessages
                    .TOO_MUCH_FUEL_EXCEPTION_MESSAGE, liters));
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}

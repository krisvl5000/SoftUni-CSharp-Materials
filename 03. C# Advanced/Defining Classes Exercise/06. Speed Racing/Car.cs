using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKm;
            TravelledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public bool DoesItHaveEnoughFuel(Car car, int distanceToTravel)
        {
            if (car.fuelAmount >= car.fuelConsumptionPerKilometer * distanceToTravel)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}

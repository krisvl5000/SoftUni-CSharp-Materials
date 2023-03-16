using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double FUEL_AVAILABLE = 65;
        private const double FUEL_CONSUMPTION_PER_RACE = 7.5;
        public TunedCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, FUEL_AVAILABLE, FUEL_CONSUMPTION_PER_RACE)
        {
        }

        public override void Drive()
        {
            base.Drive();
            
            double newHorsePower = base.HorsePower - (base.HorsePower * 3 / 100);
            int newHorsePowerRounded = (int)Math.Round(newHorsePower, 0);

            base.HorsePower = newHorsePowerRounded;
        }
    }
}

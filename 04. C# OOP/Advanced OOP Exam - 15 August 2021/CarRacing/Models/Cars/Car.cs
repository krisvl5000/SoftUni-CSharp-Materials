using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        public Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            VIN = vin;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        private string make;

        public string Make
        {
            get { return make; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidCarMake));
                }
                make = value;
            }
        }

        private string model;

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidCarModel));
                }
                model = value;
            }
        }

        private string vin;

        public string VIN
        {
            get { return vin; }
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidCarVIN));
                }
                vin = value;
            }
        }

        private int horsePower;

        public int HorsePower
        {
            get { return horsePower; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidCarHorsePower));
                }
                horsePower = value;
            }
        }

        private double fuelAvailable;

        public double FuelAvailable
        {
            get { return fuelAvailable; }
            private set
            {
                if (fuelAvailable < 0)
                {
                    fuelAvailable = 0;
                }
                fuelAvailable = value;
            }
        }

        private double fuelConsumptionPerRace;

        public double FuelConsumptionPerRace
        {
            get { return fuelConsumptionPerRace; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidCarFuelConsumption));
                }
                fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            FuelAvailable -= fuelConsumptionPerRace;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCEREMENT = 0.9;
        public Car(double fuelQuantity, 
            double fuelConsumption) : 
            base(fuelQuantity, fuelConsumption, FUEL_CONSUMPTION_INCEREMENT)
        {

        }
    }
}

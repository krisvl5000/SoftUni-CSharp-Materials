﻿using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Model = "A5";
            car.Make = "Audi";
            car.Year = 1995;
            car.FuelQuantity = 100;
            car.FuelConsumption = 2;

            for (int i = 0; i < 5; i++)
            {
                car.Drive(30);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
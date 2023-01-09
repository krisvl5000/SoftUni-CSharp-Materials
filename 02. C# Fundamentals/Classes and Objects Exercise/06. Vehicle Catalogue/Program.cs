using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> list = new List<Vehicle>();
            List<Vehicle> cars = new List<Vehicle>();
            List<Vehicle> trucks = new List<Vehicle>();

            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "End")
            {
                string type = input[0];
                string model = input[1];
                string color = input[2];
                int horsePower = int.Parse(input[3]);

                Vehicle newVehicle = new Vehicle(type, model, color, horsePower);
                list.Add(newVehicle);

                if (newVehicle.Type == "car")
                {
                    cars.Add(newVehicle);
                    newVehicle.Type = "Car";
                }
                else
                {
                    trucks.Add(newVehicle);
                    newVehicle.Type = "Truck";
                }
                input = Console.ReadLine().Split().ToArray();
            }

            string command;
            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                if (list.Any(t => t.Model == command))
                {
                    Vehicle vehicle = list.First(v => v.Model == command);

                    Console.WriteLine($"Type: {vehicle.Type}");
                    Console.WriteLine($"Model: {vehicle.Model}");
                    Console.WriteLine($"Color: {vehicle.Color}");
                    Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                }
                else
                {
                    continue;
                }

                
            }

            double totalCarHP = 0;
            double totalTruckHP = 0;

            foreach (Vehicle car in cars)
            {
                totalCarHP += car.HorsePower;
            }

            foreach (Vehicle truck in trucks)
            {
                totalTruckHP += truck.HorsePower;
            }

            double averageCarHp = totalCarHP / cars.Count;
            double averageTruckHp = totalTruckHP / trucks.Count;

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarHp:F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTruckHp:F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }

        public int Power { get; set; }
    }

    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get; set; }

        public string Type { get; set; }
    }

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Engine newEngine = new Engine(engineSpeed, enginePower);
                Cargo newCargo = new Cargo(cargoWeight, cargoType);
                Car newCar = new Car(model, newEngine, newCargo);

                carList.Add(newCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<Car> fragileCargo = carList.Where(t => t.Cargo.Weight < 1000).ToList();

                foreach (Car car in fragileCargo)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (command == "flamable")
            {
                List<Car> flamableCargo = carList.Where(t => t.Engine.Power > 250).ToList();

                foreach (Car car in flamableCargo)
                {
                    Console.WriteLine($"{car.Model}");
                }
            }

        }
    }
}
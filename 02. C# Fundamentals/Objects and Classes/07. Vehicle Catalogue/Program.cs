using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weigth = weight;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weigth { get; set; }
    }
    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
    }

    class Catalog
    {
        public Catalog()
        {
            this.Truck = new List<Truck>();
            this.Cars = new List<Car>();
        }
        public List<Car> Cars { get; set; }

        public List<Truck> Truck { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalogObject = new Catalog();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] splitParams = command.Split("/");

                string type = splitParams[0];
                string brand = splitParams[1];
                string model = splitParams[2];
                int finalParam = int.Parse(splitParams[3]);

                if (type == "Car")
                {
                    Car newCar = new Car(brand, model, finalParam);
                    catalogObject.Cars.Add(newCar);
                }
                
                if (type == "Truck")
                {
                    Truck newTruck = new Truck(brand, model, finalParam);
                    catalogObject.Truck.Add(newTruck);
                }
             

                command = Console.ReadLine();
            }

            if (catalogObject.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                List<Car> orderedCars = catalogObject.Cars.OrderBy(car => car.Brand).ToList();

                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogObject.Truck.Count > 0)
            {
                Console.WriteLine("Trucks:");
                List<Truck> orderedTrucks = catalogObject.Truck.OrderBy(truck => truck.Brand).ToList();

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weigth}kg");
                }
            }

        }
    }
}
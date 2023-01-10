using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string Name { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public override string ToString()
        {
            return $"{this.Name} -> Mileage: {this.Mileage} kms, " +
                    $"Fuel in the tank: {this.Fuel} lt.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> list = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string carName = carArgs[0];
                int mileage = int.Parse(carArgs[1]);
                int fuel = int.Parse(carArgs[2]);

                Car newCar = new Car(carName, mileage, fuel);
                list.Add(newCar);
            }

            string[] input = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Stop")
            {
                string command = input[0];
                string carName = input[1];

                Car car = list.First(x => x.Name == carName);

                if (command == "Drive")
                {
                    int distance = int.Parse(input[2]);
                    int fuel = int.Parse(input[3]);

                    if (car.Fuel >= fuel)
                    {
                        car.Mileage += distance;
                        car.Fuel -= fuel;

                        Console.WriteLine($"{car.Name} driven for {distance} " +
                            $"kilometers. {fuel} liters of fuel consumed.");

                        if (car.Mileage >= 100000)
                        {
                            list.Remove(car);
                            Console.WriteLine($"Time to sell the {car.Name}!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(input[2]);

                    if (car.Fuel + fuel > 75)
                    {
                        int counter = 0;

                        for (int i = 0; i <= 75; i++)
                        {
                            if (car.Fuel == 75 || fuel == 0)
                            {
                                break;
                            }

                            car.Fuel++;
                            fuel--;
                            counter++;
                        }

                        Console.WriteLine($"{car.Name} refueled with {counter} liters");
                    }
                    else
                    {
                        car.Fuel += fuel;
                        Console.WriteLine($"{car.Name} refueled with {fuel} liters");
                    }
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(input[2]);

                    if (car.Mileage - kilometers >= 10000)
                    {
                        car.Mileage -= kilometers;

                        Console.WriteLine($"{car.Name} mileage decreased by {kilometers} " +
                            $"kilometers");
                    }
                    else
                    {
                        car.Mileage = 10000;
                    }
                    
                }

                input = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in list)
            {
                Console.WriteLine(car);
            }

        }
    }
}
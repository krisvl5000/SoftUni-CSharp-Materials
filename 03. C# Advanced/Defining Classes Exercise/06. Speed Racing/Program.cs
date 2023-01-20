using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> list = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                double fuelAmount = double.Parse(carArgs[1]);
                double fuelConsumptionPerKm = double.Parse(carArgs[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                list.Add(car);
            }

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                //string command = input[0];
                string carModel = input[1];
                int distanceToDrive = int.Parse(input[2]);

                Car carToDrive = list.Find(x => x.Model == carModel);

                if (carToDrive.DoesItHaveEnoughFuel(carToDrive, distanceToDrive))
                {
                    carToDrive.FuelAmount -= 
                        carToDrive.FuelConsumptionPerKilometer * distanceToDrive;

                    carToDrive.TravelledDistance += distanceToDrive;
                }
                else
                {
                    Console.WriteLine("Insuffiecient fuel for the drive");
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var car in list)
            {
                Console.WriteLine(car);
            }

        }
    }
}
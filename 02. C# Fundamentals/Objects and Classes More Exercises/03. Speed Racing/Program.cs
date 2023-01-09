//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _01._Hello_Softuni
//{
//    internal class Car
//    {
//        public Car(string model, double fuelAmount, double fuelPerKm, double travelDistance)
//        {
//            Model = model;
//            FuelAmount = fuelAmount;
//            FuelPerKm = fuelPerKm;
//            TravelDistance = travelDistance;
//        }

//        public string Model { get; set; }

//        public double FuelAmount { get; set; }

//        public double FuelPerKm { get; set; }

//        public double TravelDistance { get; set; }

//        public static bool IsFuelSufficient(Car currentCar, double distanceToTravel)
//        {
//            if (currentCar.FuelAmount < currentCar.FuelPerKm * distanceToTravel)
//            {
//                //for the audi it says that it is not sufficient
//                return false;
//            }

//            return true;
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Car> carList = new List<Car>();
//            int n = int.Parse(Console.ReadLine());

//            for (int i = 0; i < n; i++)
//            {
//                string[] input = Console.ReadLine().Split().ToArray();

//                string model = input[0];
//                double fuelAmount = double.Parse(input[1]);
//                double fuelPerKm = double.Parse(input[2]);
//                double travelDistance = 0;

//                Car newCar = new Car(model, fuelAmount, fuelPerKm, travelDistance);
//                carList.Add(newCar);
//            }

//            string[] command = Console.ReadLine().Split().ToArray();
//            while (command[0] != "End")
//            {
//                command[0] = "Drive";
//                string model = command[1];
//                double distanceToTravel = double.Parse(command[2]);

//               List<Car> getCurrentCar = carList.OrderBy(b => b.Model).ToList();
//               Car currentCar = carList.Where(c => c.Model == model).FirstOrDefault();

//                if (Car.IsFuelSufficient(currentCar, distanceToTravel))
//                {
//                    //for some reason doesn't work
//                    currentCar.FuelAmount -= currentCar.FuelPerKm * distanceToTravel;
//                    currentCar.TravelDistance += distanceToTravel;
//                }
//                else
//                {
//                    Console.WriteLine("Insufficient fuel for the drive");
//                    command = Console.ReadLine().Split().ToArray();
//                    continue;
//                }

//            }

//            foreach (Car car in carList)
//            {
//                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelDistance}");
//            }

//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKM)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKM = fuelConsumptionPerKM;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKM { get; set; }

        public double TraveledDistance { get; set; } = 0;

        public static bool CanCarTravelDistance(Car currentCar, double distanceTotravel)
        {
            if (currentCar.FuelAmount < distanceTotravel * currentCar.FuelConsumptionPerKM)
            {
                return false;
            }

            return true;
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
                string[] input = Console.ReadLine().Split().ToArray();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelPerKm = double.Parse(input[2]);

                Car newCar = new Car(model, fuelAmount, fuelPerKm);
                list.Add(newCar);
            }

            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "End")
            {
                string model = command[1];
                double distanceToTravel = double.Parse(command[2]);

                Car currentCar = list.First(x => x.Model == model);

                if (Car.CanCarTravelDistance(currentCar, distanceToTravel))
                {
                    currentCar.TraveledDistance += distanceToTravel;
                    currentCar.FuelAmount -= distanceToTravel * currentCar.FuelConsumptionPerKM;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                command = Console.ReadLine().Split().ToArray();
            }

            foreach (Car car in list)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }

        }
    }
}
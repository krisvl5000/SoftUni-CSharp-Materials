using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Engine> engines = new List<Engine>();
            int numberOfEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEngines; i++)
            {
                engines.Add(GetNewEngineData());
            }

            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                cars.Add(GetNewCarData(engines));
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        public static Engine GetNewEngineData()
        {
            string[] engineData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = engineData[0];
            int power = int.Parse(engineData[1]);
            switch (engineData.Length)
            {
                case 2:
                    return new Engine(model, power);
                case 3:
                    string item = engineData[2];
                    bool isItAnInteger = int.TryParse(item, out _);

                    if (isItAnInteger)
                        return new Engine(model, power, int.Parse(item));
                    else
                        return new Engine(model, power, item);
                case 4:
                    int displacement = int.Parse(engineData[2]);
                    string efficiency = engineData[3];
                    return new Engine(model, power, displacement, efficiency);
                default:
                    return null;
            }
        }

        public static Car GetNewCarData(List<Engine> engines)
        {
            string[] carData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = carData[0];
            string engineModel = carData[1];
            Engine engine = engines.Find(e => e.Model == engineModel);
            switch (carData.Length)
            {
                case 2:
                    return new Car(model, engine);
                case 3:
                    string item = carData[2];
                    bool isItAnInteger = int.TryParse(item, out _);

                    if (isItAnInteger)
                        return new Car(model, engine, int.Parse(item));
                    else
                        return new Car(model, engine, item);
                case 4:
                    int weight = int.Parse(carData[2]);
                    string color = carData[3];
                    return new Car(model, engine, weight, color);
                default:
                    return null;
            }
        }
    }
}

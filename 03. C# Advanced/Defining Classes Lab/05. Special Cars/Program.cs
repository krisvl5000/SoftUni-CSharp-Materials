using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tireList = new List<Tire[]>();
            List<Engine> engineList = new List<Engine>();
            List<Car> carList = new List<Car>();

            string[] tireInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (tireInput[0] != "No")
            {
                int firstTireYear = int.Parse(tireInput[0]);
                double firstTirePressure = double.Parse(tireInput[1]);

                int secondTireYear = int.Parse(tireInput[2]);
                double secondTirePressure = double.Parse(tireInput[3]);

                int thirdTireYear = int.Parse(tireInput[4]);
                double thirdTirePressure = double.Parse(tireInput[5]);

                int fourthTireYear = int.Parse(tireInput[6]);
                double fourthTirePressure = double.Parse(tireInput[7]);

                Tire[] tires = new Tire[4];
                {
                    tires[0] = new Tire(firstTireYear, firstTirePressure);
                    tires[1] = new Tire(secondTireYear, secondTirePressure);
                    tires[2] = new Tire(thirdTireYear, thirdTirePressure);
                    tires[3] = new Tire(fourthTireYear, fourthTirePressure);
                };

                tireList.Add(tires);

                tireInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] engineInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (engineInput[0] != "Engines")
            {
                int horsePower = int.Parse(engineInput[0]);
                double cubicCapacity = double.Parse(engineInput[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engineList.Add(engine);

                engineInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] carInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (carInput[0] != "Show")
            {
                string make = carInput[0];
                string model = carInput[1];
                int year = int.Parse(carInput[2]);
                double fuelConsumption = double.Parse(carInput[3]);
                double fuelQuantity = double.Parse(carInput[4]);

                int engineIndex = int.Parse(carInput[5]);
                int tiresIndex = int.Parse(carInput[6]);

                Car car = new Car(make, model, year, fuelQuantity,
                    fuelConsumption, engineList[engineIndex], tireList[tiresIndex]);

                carList.Add(car);

                carInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            List<Car> specialCarList = carList
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tire
                .Sum(b => b.Pressure) >= 9 && x.Tire
                .Sum(b => b.Pressure) <= 10)
                .ToList();

            foreach (var car in specialCarList)
            {
                car.Drive(20);
                Console.WriteLine(car);
            }
        }
    }
}
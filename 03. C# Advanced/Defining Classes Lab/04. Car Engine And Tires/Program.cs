using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[]
            {
                new Tire(1995, 1.6),
                new Tire(1995, 1.6),
                new Tire(1995, 1.9),
                new Tire(1995, 1.9)
            };

            Car defaultCar = new Car("BMW", "X3", 2006, 100000, 5000);
            Console.WriteLine(defaultCar.WhoAmI());

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
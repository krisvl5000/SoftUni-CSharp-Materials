using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        public List<Car> Cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.Cars = new List<Car>();
        }

        public void AddCar(Car car, string regNumber)
        {
            if (Cars.Any(x => x.RegistrationNumber == regNumber))
            {
                if (Cars.Count >= capacity)
                {
                    Console.WriteLine("Parking is full!");
                }
                else
                {
                    Cars.Add(car);
                    Console.WriteLine($"Successfully added " +
                        $"new car {car.Make} {car.RegistrationNumber}");
                }
            }
            else
            {
                Console.WriteLine("Car with that registration number, already exists!");
            }
        }

        public void RemoveCar(string regNumber)
        {
            if (!Cars.Any(x => x.RegistrationNumber == regNumber))
            {
                Console.WriteLine("Car with that registration number, doesn't exist!");
            }
            else
            {
                Car carToRemove = Cars.Find(x => x.RegistrationNumber == regNumber);
                Cars.Remove(carToRemove);
            }
        }
    }
}

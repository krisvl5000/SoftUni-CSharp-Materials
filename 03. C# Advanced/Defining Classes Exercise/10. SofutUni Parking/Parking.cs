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

        public int Count => Cars.Count;

        public string AddCar(Car car)
        {
            string regNumber = car.RegistrationNumber;

            if (!Cars.Any(x => x.RegistrationNumber == regNumber))
            {
                if (Cars.Count >= capacity)
                {
                    return "Parking is full!";
                }
                else
                {
                    Cars.Add(car);
                    return $"Successfully added " +
                        $"new car {car.Make} {car.RegistrationNumber}";
                }
            }
            else
            {
                return "Car with that registration number, already exists!";
            }
        }

        public string RemoveCar(string regNumber)
        {
            if (!Cars.Any(x => x.RegistrationNumber == regNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = Cars.Find(x => x.RegistrationNumber == regNumber);
                Cars.Remove(carToRemove);

                return $"Successfully removed {regNumber}";
            }
        }

        public string GetCar(string regNumber)
        {
            Car carToGet = Cars.FirstOrDefault(x => x.RegistrationNumber == regNumber);
            return $"{carToGet}";
        }

        public void RemoveSetOfRegistrationNumber(List<string> regNumbers)
        {
            foreach (var number in regNumbers)
            {
                foreach (var car in Cars)
                {
                    if (car.RegistrationNumber == number)
                    {
                        Cars.Remove(car);
                    }
                }
            }
        }

    }
}

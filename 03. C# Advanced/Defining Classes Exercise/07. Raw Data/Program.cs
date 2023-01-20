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
            List<Car> fragileCargo = new List<Car>();
            List<Car> flammableCargo = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                double cargoWeight = double.Parse(input[3]);
                string cargotype = input[4];
                Cargo cargo = new Cargo(cargotype, cargoWeight);

                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                Tire tire1 = new Tire(tire1Age, tire1Pressure);

                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);

                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);

                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);

                Tire[] tires = new Tire[4]
                {
                    tire1, tire2, tire3, tire4
                };

                Car car = new Car(model, engine, cargo, tires);
                list.Add(car);

                if (cargo.Type == "fragile")
                {
                    foreach (var item in tires)
                    {
                        if (item.Pressure < 1)
                        {
                            fragileCargo.Add(car);
                            break;
                        }
                    }
                }
                else if (cargo.Type == "flammable" && engine.Power > 250)
                {
                    flammableCargo.Add(car);
                }
                
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in fragileCargo)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in flammableCargo)
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}
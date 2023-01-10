using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class City
    {
        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public string Name { get; set; }

        public int Population { get; set; }

        public int Gold { get; set; }

        public override string ToString()
        {
            return $"{this.Name} -> Population: " +
                        $"{this.Population} citizens, Gold: {this.Gold} kg";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> list = new List<City>();

            string[] cmdArgs = Console.ReadLine().Split("||");

            while (cmdArgs[0] != "Sail")
            {
                string name = cmdArgs[0];
                int population = int.Parse(cmdArgs[1]);
                int gold = int.Parse(cmdArgs[2]);

                City newCity = new City(name, population, gold);

                if (list.Any(x => x.Name == name))
                {
                    City cityToAddTo = list.First(x => x.Name == name);
                    cityToAddTo.Population += population;
                    cityToAddTo.Gold += gold;
                }
                else
                {
                    list.Add(newCity);
                }

                cmdArgs = Console.ReadLine().Split("||");
            }

            string[] input = Console.ReadLine().Split("=>");

            while (input[0] != "End")
            {
                string command = input[0];
                string cityName = input[1];

                City city = list.First(x => x.Name == cityName);

                if (command == "Plunder")
                {
                    int people = int.Parse(input[2]);
                    int gold = int.Parse(input[3]);

                    Console.WriteLine($"{city.Name} plundered! {gold} gold stolen, " +
                        $"{people} citizens killed.");

                    city.Population -= people;
                    city.Gold -= gold;

                    if (city.Population <= 0 || city.Gold <= 0)
                    {
                        list.Remove(city);
                        Console.WriteLine($"{city.Name} has been wiped off the map!");
                    }
                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(input[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        city.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. " +
                            $"{city.Name} now has {city.Gold} gold.");
                    }
                }

                input = Console.ReadLine().Split("=>");
            }

            if (list.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {list.Count} " +
                $"wealthy settlements to go to:");

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered " +
                    $"and destroyed!");
            }
            

        }
    }
}
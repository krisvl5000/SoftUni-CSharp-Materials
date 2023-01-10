using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
        }

        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<double> Rating { get; set; } = new List<double>();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> list = new List<Plant>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] plantArgs = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string name = plantArgs[0];
                int rarity = int.Parse(plantArgs[1]);

                if (!list.Any(x => x.Name == name))
                {
                    Plant newPlant = new Plant(name, rarity);
                    list.Add(newPlant);
                }
                else
                {
                    Plant plant = list.First(x => x.Name == name);
                    plant.Rarity = rarity;
                }
            }

            string[] input = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Exhibition")
            {
                string command = input[0];

                if (command == "Rate")
                {
                    string[] cmdArgs = input[1].Split(" - ");

                    string plantName = cmdArgs[0];
                    int rating = int.Parse(cmdArgs[1]);

                    if (list.Any(x => x.Name == plantName))
                    {
                        Plant plant = list.First(x => x.Name == plantName);
                        plant.Rating.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (command == "Update")
                {
                    string[] cmdArgs = input[1]
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plantName = cmdArgs[0];
                    int newRarity = int.Parse(cmdArgs[1]);

                    if (list.Any(x => x.Name == plantName))
                    {
                        Plant plant = list.First(x => x.Name == plantName);
                        plant.Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    
                }
                else if (command == "Reset")
                {
                    string plantName = input[1];

                    if (list.Any(x => x.Name == plantName))
                    {
                        Plant plant = list.First(x => x.Name == plantName);
                        plant.Rating.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    
                }

                input = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in list)
            {
                double average;

                if (plant.Rating.Count > 0)
                {
                    average = plant.Rating.Average();
                }
                else
                {
                    average = 0;
                }

                Console.WriteLine($"- {plant.Name}; " +
                    $"Rarity: {plant.Rarity}; Rating: {average:F2}");

            }

        }
    }
}
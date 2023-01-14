using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                string[] clothing = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!dict.ContainsKey(color))
                {
                    dict[color] = new Dictionary<string, int>();
                }

                foreach (var item in clothing)
                {
                    if (!dict[color].ContainsKey(item))
                    {
                        dict[color].Add(item, 0);
                    }

                    dict[color][item]++;
                }
            }

            string[] clothesArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string colorToLookFor = clothesArgs[0];
            string clothingToLookFor = clothesArgs[1];

            foreach (var color in dict)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clothing in color.Value)
                {
                    if (color.Key == colorToLookFor && clothing.Key == clothingToLookFor)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                }
            }

        }
    }
}
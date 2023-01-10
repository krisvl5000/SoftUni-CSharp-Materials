using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();

            string resourceOrStop = Console.ReadLine();

            int quantity;

            while (resourceOrStop != "stop")
            {
                quantity = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(resourceOrStop))
                {
                    dict.Add(resourceOrStop, quantity);
                }
                else
                {
                    dict[resourceOrStop] += quantity;
                }



                resourceOrStop = Console.ReadLine();
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
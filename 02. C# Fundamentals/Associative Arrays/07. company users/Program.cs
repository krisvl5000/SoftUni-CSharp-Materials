using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" -> ");

            while (input[0] != "End")
            {
                string company = input[0];
                string id = input[1];

                if (!dict.ContainsKey(company))
                {
                    dict.Add(company, new List<string>());
                }

                if (!dict[company].Contains(id))
                {
                    dict[company].Add(id);
                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var company in dict)
            {
                Console.WriteLine($"{company.Key}");

                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }

        }
    }
}
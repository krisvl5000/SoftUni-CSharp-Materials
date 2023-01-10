using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                }

                dict[name].Add(grade);
            }

            foreach (var person in dict)
            {
                double average = person.Value.Average();

                if (average >= 4.5)
                {
                    Console.WriteLine($"{person.Key} -> {average:F2}");
                }
            }

        }
    }
}
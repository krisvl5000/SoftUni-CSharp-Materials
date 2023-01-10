using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Average_Student_Grafes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> map = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal value = decimal.Parse(input[1]);

                if (!map.ContainsKey(name))
                {
                    map[name] = new List<decimal>();
                    map[name].Add(value);
                }
                else
                {
                    map[name].Add(value);
                }
            }

            foreach (var student in map)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():F2})");
            }
        }
    }
}

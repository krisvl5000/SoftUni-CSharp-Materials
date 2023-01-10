using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            SortedDictionary<int, int> occurences = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                if (occurences.ContainsKey(number))
                {
                    occurences[number]++;
                }
                else
                {
                    occurences.Add(number, 1);
                }
            }

            foreach (var item in occurences)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
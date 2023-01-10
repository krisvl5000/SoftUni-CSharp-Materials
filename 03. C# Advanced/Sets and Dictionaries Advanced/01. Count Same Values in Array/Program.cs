using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (var item in input)
            {
                if (!map.ContainsKey(item))
                {
                    map[item] = 1;
                }
                else
                {
                    map[item]++;
                }
            }

            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}

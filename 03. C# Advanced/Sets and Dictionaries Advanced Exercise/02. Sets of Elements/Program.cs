using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstSet = sizes[0];
            int secondSet = sizes[1];

            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < firstSet; i++)
            {
                int input = int.Parse(Console.ReadLine());

                set1.Add(input);
            }

            for (int i = 0; i < secondSet; i++)
            {
                int input = int.Parse(Console.ReadLine());

                set2.Add(input);
            }

            foreach (var item in set1)
            {
                if (set2.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }

        }
    }
}
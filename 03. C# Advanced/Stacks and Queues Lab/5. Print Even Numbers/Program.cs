using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            foreach (var item in input)
            {
                if (item % 2 == 0)
                {
                    queue.Enqueue(item);
                }
            }

            Console.WriteLine(String.Join(", ", queue));

        }
    }
}
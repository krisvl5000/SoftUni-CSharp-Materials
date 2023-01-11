using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            foreach (var item in orders)
            {
                queue.Enqueue(item);
            }

            int biggestOrder = queue.Peek();

            foreach (var item in orders)
            {
                if (item > biggestOrder)
                {
                    biggestOrder = item;
                }
            }

            Console.WriteLine(biggestOrder);

            while (queue.Count > 0)
            {
                if (quantity - queue.Peek() >= 0)
                {
                    quantity -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
            }

        }
    }
}
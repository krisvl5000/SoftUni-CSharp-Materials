using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split();

            Queue<string> queue = new Queue<string>();

            int n = int.Parse(Console.ReadLine());

            foreach (var item in people)
            {
                queue.Enqueue(item);
            }

            int counter = 1;
            while (queue.Count != 1)
            {
                if (n == 1)
                {
                    while (queue.Count != 1)
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}"); 
                    }
                }

                queue.Enqueue(queue.First());
                queue.Dequeue();

                counter++;

                if (counter == n)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                    counter = 1;
                }
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            var queue = new Queue<string>();
            
            int counter = 0;
            int totalCarsPassed = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    while (queue.Count != 0 && counter < n)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        totalCarsPassed++;
                        counter++;
                    }

                    counter = 0;

                    input = Console.ReadLine();
                    continue;
                }

                queue.Enqueue(input);
                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");

        }
    }
}
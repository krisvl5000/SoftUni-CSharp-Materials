using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] queueArgs = Console.ReadLine().Split(", ");

            Queue<string> queue = new Queue<string>(queueArgs);

            string[] input = Console.ReadLine().Split();

            while (queue.Count > 0)
            {
                string command = input[0];

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Add")
                {
                    string songRequested = string.Join(" ", input);
                    string song = songRequested.Remove(0, 4);
                    
                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }

                }
                else if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }


                if (queue.Count == 0)
                {
                    break;
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine("No more songs!");

        }
    }
}
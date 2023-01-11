using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] stackArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int itemsToEnqueue = stackArgs[0];
            int itemsToDequeue = stackArgs[1];
            int itemToLookFor = stackArgs[2];

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            foreach (var item in arr)
            {
                queue.Enqueue(item);
            }

            for (int i = 0; i < itemsToDequeue; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(itemToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int minNum = queue.Peek();

                    foreach (var item in queue)
                    {
                        if (item < minNum)
                        {
                            minNum = item;
                        }
                    }

                    Console.WriteLine(minNum);
                }
            }
            else
            {
                Console.WriteLine(0);
            }


        }
    }
}
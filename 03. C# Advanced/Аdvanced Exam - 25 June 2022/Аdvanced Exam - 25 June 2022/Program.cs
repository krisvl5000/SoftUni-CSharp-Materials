using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] greyTiles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> whiteStack = new Stack<int>(whiteTiles);
            Queue<int> greyQueue = new Queue<int>(greyTiles);

            int sink = 0;
            int oven = 0;
            int counterTop = 0;
            int wall = 0;
            int floor = 0;

            while (whiteStack.Count > 0 && greyQueue.Count > 0)
            {
                int whiteTile = whiteStack.Pop();
                int greyTile = greyQueue.Dequeue();

                if (whiteTile == greyTile)
                {
                    int newTile = whiteTile + greyTile;

                    if (newTile == 40)
                    {
                        sink++;
                    }
                    else if (newTile == 50)
                    {
                        oven++;
                    }
                    else if (newTile == 60)
                    {
                        counterTop++;
                    }
                    else if (newTile == 70)
                    {
                        wall++;
                    }
                    else
                    {
                        floor++;
                    }
                }
                else
                {
                    whiteStack.Push(whiteTile / 2);
                    greyQueue.Enqueue(greyTile);
                }
            }

            if (whiteStack.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {String.Join(", ", whiteStack)}");
            }

            if (greyQueue.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {String.Join(", ", greyQueue)}");
            }

            Dictionary<string, int> dict = new Dictionary<string, int>();

            dict.Add("Countertop", counterTop);
            dict.Add("Floor", floor);
            dict.Add("Oven", oven);
            dict.Add("Sink", sink);
            dict.Add("Wall", wall);

            foreach (var tile in dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (tile.Value > 0)
                {
                    Console.WriteLine($"{tile.Key}: {tile.Value}");
                }
            }
        }
    }
}
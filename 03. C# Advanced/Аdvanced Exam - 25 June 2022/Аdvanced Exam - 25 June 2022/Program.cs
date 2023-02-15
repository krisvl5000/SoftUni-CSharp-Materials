using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> white = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> grey = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var dict = new Dictionary<string, int>();
            dict.Add("Sink", 40);
            dict.Add("Oven", 50);
            dict.Add("Countertop", 60);
            dict.Add("Wall", 70);

            var itemsMade = new Dictionary<string, int>();

            while (true)
            {
                int whiteTile = white.Peek();
                int greyTile = grey.Peek();

                if (whiteTile == greyTile)
                {
                    int largeTile = whiteTile + greyTile;

                    bool itemIsPresent = false;

                    foreach (var item in dict)
                    {
                        if (item.Value == largeTile)
                        {
                            if (!itemsMade.ContainsKey(item.Key))
                            {
                                itemsMade.Add(item.Key, 0);
                            }

                            itemsMade[item.Key]++;
                            itemIsPresent = true;
                            break;
                        }
                    }

                    if (!itemIsPresent)
                    {
                        if (!itemsMade.ContainsKey("Floor"))
                        {
                            itemsMade.Add("Floor", 0);
                        }

                        itemsMade["Floor"]++;
                    }

                    white.Pop();
                    grey.Dequeue();
                }
                else
                {
                    whiteTile = white.Pop();
                    whiteTile /= 2;
                    white.Push(whiteTile);

                    grey.Enqueue(grey.Dequeue());
                }

                if (white.Count == 0 || grey.Count == 0)
                {
                    break;
                }
            }

            if (white.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {String.Join(", ", white)}");
            }

            if (grey.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {String.Join(", ", grey)}");
            }

            var orderedDict = itemsMade
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            foreach (var item in orderedDict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
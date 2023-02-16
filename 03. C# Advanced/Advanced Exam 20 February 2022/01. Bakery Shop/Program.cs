using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waterQueue = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray());

            Stack<double> flourStack = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray());

            var dict = new Dictionary<string, int>();

            dict.Add("Croissant", 50);
            dict.Add("Muffin", 40);
            dict.Add("Baguette", 30);
            dict.Add("Bagel", 20);

            var productsMade = new Dictionary<string, int>();

            while (waterQueue.Count != 0 && flourStack.Count != 0)
            {
                bool itemWasMade = false;

                double water = waterQueue.Peek();
                double flour = flourStack.Peek();
                double waterRatio = water * 100 / (water + flour);

                foreach (var item in dict)
                {
                    if (waterRatio == item.Value)
                    {
                        if (!productsMade.ContainsKey(item.Key))
                        {
                            productsMade.Add(item.Key, 0);
                        }

                        productsMade[item.Key]++;
                        itemWasMade = true;
                        break;
                    }
                }

                if (itemWasMade)
                {
                    waterQueue.Dequeue();
                    flourStack.Pop();

                    continue;
                }
                else
                {
                    if (flour < water)
                    {
                        while (flour < water)
                        {
                            flour += flourStack.Pop();

                            if (!flourStack.Any())
                            {
                                break;
                            }
                        }
                    }

                    flour -= water;

                    if (!productsMade.ContainsKey("Croissant"))
                    {
                        productsMade.Add("Croissant", 0);
                    }

                    productsMade["Croissant"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                    flourStack.Push(flour);
                }

            }

            var orderedDict = productsMade
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);

            foreach (var item in orderedDict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (waterQueue.Any())
            {
                Console.WriteLine($"Water left: {String.Join(", ", waterQueue)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flourStack.Any())
            {
                Console.WriteLine($"Flour left: {String.Join(", ", flourStack)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }
    }
}
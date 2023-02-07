using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterArr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Queue<double> waterQueue = new Queue<double>(waterArr);

            double[] flourArr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Stack<double> flourStack = new Stack<double>(flourArr);

            var dict = new Dictionary<string, int>();

            while (waterQueue.Count > 0 && flourStack.Count > 0)
            {
                double water = waterQueue.Peek();
                double flour = flourStack.Peek();

                double waterRatio = water * 100 / (water + flour);

                if (waterRatio == 50)
                {
                    if (!dict.ContainsKey("Croissant"))
                    {
                        dict.Add("Croissant", 0);
                    }

                    dict["Croissant"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else if (waterRatio == 40)
                {
                    if (!dict.ContainsKey("Muffin"))
                    {
                        dict.Add("Muffin", 0);
                    }

                    dict["Muffin"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else if (waterRatio == 30)
                {
                    if (!dict.ContainsKey("Baguette"))
                    {
                        dict.Add("Baguette", 0);
                    }

                    dict["Baguette"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else if (waterRatio == 20)
                {
                    if (!dict.ContainsKey("Bagel"))
                    {
                        dict.Add("Bagel", 0);
                    }

                    dict["Bagel"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else
                {
                    flourStack.Pop();
                    waterQueue.Dequeue();

                    if (!dict.ContainsKey("Croissant"))
                    {
                        dict.Add("Croissant", 0);
                    }

                    dict["Croissant"]++;

                    //water 25, flour 30

                    if (flour > water)
                    {
                        double leftOverFlour = flour - water;
                        flourStack.Push(leftOverFlour);
                    }
                    else
                    {
                        double leftOverWater = water - flour;
                        waterQueue.Enqueue(leftOverWater);
                    }
                }
            }

            foreach (var item in dict
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (waterQueue.Count > 0)
            {
                Console.WriteLine(String.Join(", ", waterQueue));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flourStack.Count > 0)
            {
                Console.WriteLine(String.Join(", ", flourStack));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
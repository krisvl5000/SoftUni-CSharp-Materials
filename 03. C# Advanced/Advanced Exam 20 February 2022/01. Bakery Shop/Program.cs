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

            while (waterQueue.Count > 0 || flourStack.Count > 0)
            {
                double water = waterQueue.Peek();
                double flour = flourStack.Peek();

                double waterRatio = water * 100 / (water + flour);

                if (waterRatio == 50)
                {
                    if (!dict.ContainsKey("croissant"))
                    {
                        dict.Add("croissant", 0);
                    }

                    dict["croissant"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else if (waterRatio == 40)
                {
                    if (!dict.ContainsKey("muffin"))
                    {
                        dict.Add("muffin", 0);
                    }

                    dict["muffin"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else if (waterRatio == 30)
                {
                    if (!dict.ContainsKey("baguette"))
                    {
                        dict.Add("baguette", 0);
                    }

                    dict["baguette"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else if (waterRatio == 20)
                {
                    if (!dict.ContainsKey("bagel"))
                    {
                        dict.Add("bagel", 0);
                    }

                    dict["bagel"]++;

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else
                {
                    if (!dict.ContainsKey("croissant"))
                    {
                        dict.Add("croissant", 0);
                    }

                    dict["croissant"]++;

                    double flourUsed = flourStack.Pop();
                    flourUsed -= water;
                    flourStack.Push(flourUsed);

                    while (flour < water) // might need some refactoring
                    {
                        flourUsed = flourStack.Pop();
                        flourUsed -= water;
                        flourStack.Push(flourUsed);
                    }
                }
            }



        }
    }
}
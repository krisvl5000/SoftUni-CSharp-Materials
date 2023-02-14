using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hatsStack = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> scarfsQueue = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            List<int> sets = new List<int>();

            while (true)
            {
                if (hatsStack.Count == 0)
                {
                    break;
                }
                if (scarfsQueue.Count == 0)
                {
                    break;
                }

                if (hatsStack.Peek() > scarfsQueue.Peek())
                {
                    int newSet = hatsStack.Peek() + scarfsQueue.Peek();
                    sets.Add(newSet);

                    hatsStack.Pop();
                    scarfsQueue.Dequeue();
                    continue;
                }
                else if (scarfsQueue.Peek() > hatsStack.Peek())
                {
                    hatsStack.Pop();
                    continue;
                }
                else if (hatsStack.Peek() == scarfsQueue.Peek())
                {
                    scarfsQueue.Dequeue();
                    hatsStack.Push(hatsStack.Pop() + 1);
                    continue;
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(String.Join(" ", sets));
        }
    }
}
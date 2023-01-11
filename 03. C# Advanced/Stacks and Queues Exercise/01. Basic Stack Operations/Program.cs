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

            int itemsToPush = stackArgs[0];
            int itemsToPop = stackArgs[1];
            int itemToLookFor = stackArgs[2];

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            foreach (var item in arr)
            {
                stack.Push(item);
            }

            for (int i = 0; i < itemsToPop; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            if (stack.Count > 0)
            {
                if (stack.Contains(itemToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int minNum = stack.Peek();

                    foreach (var item in stack)
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
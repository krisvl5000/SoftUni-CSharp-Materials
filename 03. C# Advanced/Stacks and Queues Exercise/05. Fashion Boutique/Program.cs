using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            int rackNumber = 1;

            foreach (var item in clothes)
            {
                stack.Push(item);
            }

            int currentBox = 0;

            foreach (var item in clothes)
            {
                if (currentBox + stack.Peek() <= capacity)
                {
                    currentBox += stack.Pop();
                }
                else
                {
                    currentBox = 0;
                    rackNumber++;

                    currentBox += stack.Pop();
                }
            }

            Console.WriteLine(rackNumber);

        }
    }
}
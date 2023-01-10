using System;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            int length = stack.Count;

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
            
        }
    }
}
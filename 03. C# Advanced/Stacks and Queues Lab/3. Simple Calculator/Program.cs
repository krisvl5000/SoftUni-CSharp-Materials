using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            int result = 0;

            bool operatorPlus = true;

            while (stack.Count != 0)
            {
                string item = stack.Pop();

                if (item == "+")
                {
                    operatorPlus = true;
                }
                else if (item == "-")
                {
                    operatorPlus = false;
                }
                else if (operatorPlus)
                {
                    result += int.Parse(item);
                }
                else if (!operatorPlus)
                {
                    result -= int.Parse(item);
                }
            }

            Console.WriteLine(result);

        }
    }
}
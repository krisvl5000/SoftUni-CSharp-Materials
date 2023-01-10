using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            foreach (var item in intArr)
            {
                stack.Push(item);
            }

            int sum = 0;

            string[] input = Console.ReadLine().Split();

            while (true)
            {
                string command = input[0].ToLower();

                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    int firstNum = int.Parse(input[1]);
                    int secondNum = int.Parse(input[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command == "remove")
                {
                    int numToPop = int.Parse(input[1]);

                    if (stack.Count >= numToPop)
                    {
                        int counter = 0;
                        while (counter < numToPop)
                        {
                            stack.Pop();
                            counter++;
                        }
                    }
                }

                input = Console.ReadLine().Split();
            }

            int remainingSum = 0;

            if (stack.Count > 0)
            {
                while (stack.Count > 0)
                {
                    remainingSum += stack.Pop();
                }

                Console.WriteLine($"Sum: {remainingSum}");
            }
            else
            {
                Console.WriteLine("Sum: 0");
            }

        }
    }
}
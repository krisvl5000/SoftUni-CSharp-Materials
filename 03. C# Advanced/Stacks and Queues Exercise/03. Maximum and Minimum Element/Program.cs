using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                int command = input[0];

                if (command == 1)
                {
                    stack.Push(input[1]);
                }
                else if (command == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (command == 3)
                {
                    if (stack.Count > 0)
                    {
                        int maxNum = stack.Peek();

                        foreach (var item in stack)
                        {
                            if (item > maxNum)
                            {
                                maxNum = item;
                            }
                        }

                        Console.WriteLine(maxNum);
                    }
                }
                else if (command == 4)
                {
                    if (stack.Count > 0)
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

                if (i == n - 1)
                {
                    break;
                }

                input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            Console.WriteLine(String.Join(", ", stack));

        }
    }
}
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

            string text = "";

            Stack<string> stack = new Stack<string>();
            stack.Push(text);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];

                if (command == "1")
                {
                    string stringToAppend = input[1];
                    text += stringToAppend;
                    stack.Push(text);
                }
                else if (command == "2")
                {
                    int countToErase = int.Parse(input[1]);

                    text = text.Remove(text.Length - countToErase); // might need changing
                    stack.Push(text);
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    stack.Pop();
                    text = stack.Peek();
                }
            }

        }
    }
}
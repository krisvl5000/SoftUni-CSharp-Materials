using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parentheses = new Stack<char>();

            bool isBalanced = true;

            Dictionary<char, char> parDefinitions = new Dictionary<char, char>()
            {
                { '}', '{' }, { ')', '(' }, {']', '[' }
            };

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (parDefinitions.Any(x => x.Value == symbol))
                {
                    parentheses.Push(symbol);
                }
                else if (parDefinitions.Any(x => x.Key == symbol))
                {
                    if (parentheses.Count > 0 && parDefinitions[symbol] 
                        == parentheses.Peek())
                    {
                        parentheses.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (parentheses.Count > 0)
            {
                isBalanced = false;
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            string input = Console.ReadLine();

            string pattern = 
                @"(@|#)(?<firstWord>[A-Za-z]{3,})(\1)(\1)(?<secondWord>[A-Za-z]{3,})(\1)";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;

                string secondWordReversed = string.Empty;

                Stack<char> stack = new Stack<char>();

                foreach (var ch in secondWord)
                {
                    stack.Push(ch);
                }

                foreach (var ch in secondWord)
                {
                    secondWordReversed += stack.Pop();
                }

                if (firstWord == secondWordReversed)
                {
                    map.Add(firstWord, secondWord);
                }
            }

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                if (map.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");

                    List<string> list = new List<string>();

                    foreach (var item in map)
                    {
                        string wordPairs = $"{item.Key} <=> {item.Value}";
                        list.Add(wordPairs);
                    }

                    Console.WriteLine(String.Join(", ", list));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }

        }
    }
}
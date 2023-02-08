using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vowelsArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            char[] consonantsArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            Queue<char> vowels = new Queue<char>(vowelsArr);
            Stack<char> consonants = new Stack<char>(consonantsArr);

            HashSet<string> wordSet = new HashSet<string>(new string[] 
            { "pear", "flour", "pork", "olive" });

            HashSet<char> usedLetters = new HashSet<char>();

            while (consonants.Any())
            {
                usedLetters.Add(consonants.Pop());
                usedLetters.Add(vowels.Peek());
                vowels.Enqueue(vowels.Dequeue());
            }

            List<string> validWords = new List<string>();

            foreach (var word in wordSet)
            {
                if (String.Join("", word.Intersect(usedLetters)) == word)
                {
                    validWords.Add(word);
                }
            }

            Console.WriteLine($"Word found: {validWords.Count}");
            Console.WriteLine(String.Join("\n", validWords));
        }
    }
}
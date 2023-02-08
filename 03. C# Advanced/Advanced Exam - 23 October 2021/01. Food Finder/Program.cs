using System;

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

            Queue<char> vowelsQueue = new Queue<char>(vowelsArr);
            Stack<char> consonantsStack = new Stack<char>(consonantsArr);

            List<string> completeWords = new List<string>();

            var dict = new Dictionary<string, int>();
            dict.Add("pear", 4);
            dict.Add("flour", 5);
            dict.Add("pork", 4);
            dict.Add("olive", 5);

            while (consonantsStack.Count > 0)
            {
                char vowel = vowelsQueue.Dequeue();
                char consonant = consonantsStack.Pop();

                foreach (var item in dict)
                {
                    string key = item.Key;
                    if (key.Contains(vowel) || key.Contains(consonant))
                    {
                        dict[key]--;

                        if (dict[key] == 0)
                        {
                            completeWords.Add(key);
                            dict.Remove(key);
                        }
                    }
                }

                vowelsQueue.Enqueue(vowel);
            }

            Console.WriteLine($"Words found: {completeWords.Count}");

            foreach (var item in completeWords)
            {
                Console.WriteLine(item);
            }

        }
    }
}
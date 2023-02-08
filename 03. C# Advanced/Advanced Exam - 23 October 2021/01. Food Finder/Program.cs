using System;
using System.Linq;
using System.Linq.Expressions;

namespace _01._Hello_Softuni
{
    class Dict
    {
        public List<KVP> List { get; set; } = new List<KVP>();
    }

    class KVP
    {
        public KVP(string key, int value)
        {
            Key = key;
            Value = value;
            FoundLetters = new List<char>();
        }

        public string Key { get; set; }

        public int Value { get; set; }

        public List<char> FoundLetters { get; set; }
    }
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

            Dict dict = new Dict();

            dict.List.Add(new KVP("pear", 4));
            dict.List.Add(new KVP("flour", 5));
            dict.List.Add(new KVP("pork", 4));
            dict.List.Add(new KVP("olive", 5));

            while (consonantsStack.Count > 0)
            {
                char vowel = vowelsQueue.Dequeue();
                char consonant = consonantsStack.Pop();



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
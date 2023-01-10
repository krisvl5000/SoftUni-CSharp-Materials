using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(wordToRemove))
            {
                int startIndex = text.IndexOf(wordToRemove);
                text = text.Remove(startIndex, wordToRemove.Length);
            }

            Console.WriteLine(text);

        }
    }
}
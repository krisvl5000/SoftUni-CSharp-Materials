using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                string replacement = new string('*', word.Length);

                text = text.Replace(word, replacement);   
            }

            Console.WriteLine(text);
        }
    }
}
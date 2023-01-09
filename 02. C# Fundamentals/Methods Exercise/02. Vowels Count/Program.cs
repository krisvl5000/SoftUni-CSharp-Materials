using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(VowelCount(input));

        }

        static string VowelCount(string input)
        {
            char[] chars = input.ToCharArray();

            int vowelSum = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if ((chars[i] == 'a') || (chars[i] == 'e') || (chars[i] == 'i')
                        || (chars[i] == 'o') || (chars[i] == 'u') || (chars[i] == 'A')
                       || (chars[i] == 'E') || (chars[i] == 'I') || (chars[i] == 'O') ||
                       (chars[i] == 'U'))
                {
                    vowelSum++;
                }
            }

            string vowels = Convert.ToString(vowelSum);

            return vowels;
        }
    }
}
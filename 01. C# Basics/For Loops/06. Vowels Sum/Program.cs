using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            
            int value = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];

                if (currentChar == 'a')
                {
                    value++;
                }
                else if (currentChar == 'e')
                {
                    value += 2;
                }
                else if (currentChar == 'i')
                {
                    value += 3;
                }
                else if (currentChar == 'o')
                {
                    value += 4;
                }
                else if (currentChar == 'u')
                {
                    value += 5;
                }
                
            }
            Console.WriteLine(value);


        }
    }
}
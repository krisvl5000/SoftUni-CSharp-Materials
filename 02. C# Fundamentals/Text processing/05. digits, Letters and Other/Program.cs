using System;
using System.Text;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            char[] allDigits = text.Where(item => char.IsDigit(item)).ToArray();
            char[] allLetters = text.Where(item => char.IsLetter(item)).ToArray();
            char[] allOtherChars = text
                .Where((item) => !char.IsLetterOrDigit(item))
                .ToArray();

            Console.WriteLine(new string(allDigits));
            Console.WriteLine(new string(allLetters));
            Console.WriteLine(new string(allOtherChars));
            
        }
    }
}
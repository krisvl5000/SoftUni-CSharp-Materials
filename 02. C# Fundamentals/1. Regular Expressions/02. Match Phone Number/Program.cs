using System;
using System.Text.RegularExpressions;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359( |-)2(\1)[0-9]{3}(\1)[0-9]{4}\b";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine(String.Join(", ", matches));
        }
    }
}
using System;
using System.Text;

internal class Program
{
    static void Main()
    {
        string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double finalResult = 0;

        foreach (string s in strings)
        {
            var sb = new StringBuilder();
            sb.Append(s);

            char firstLetter = sb[0];
            char secondLetter = sb[sb.Length - 1];

            sb.Remove(sb.Length - 1, 1);
            sb.Remove(0, 1);
            double number = double.Parse(sb.ToString());

            if (char.IsUpper(firstLetter))
            {
                number /= ((int)firstLetter - 'A' + 1);
            }
            else if (char.IsLower(firstLetter))
            {
                number *= ((int)firstLetter - 'a' + 1);
            }

            if (char.IsUpper(secondLetter))
            {
                number -= ((int)secondLetter - 'A' + 1);
            }
            else if (char.IsLower(secondLetter))
            {
                number += ((int)secondLetter - 'a' + 1);
            }

            finalResult += number;
        }

        finalResult = Math.Round(finalResult, 2, MidpointRounding.AwayFromZero);
        Console.WriteLine($"{finalResult:f2}");
    }
}
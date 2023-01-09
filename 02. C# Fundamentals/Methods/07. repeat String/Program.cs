using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string template = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());

            Console.WriteLine(Repeater(template, repeatTimes));

        }

        static string Repeater(string template, int numberOfRepeats)
        {
            string result = string.Empty;

            for (int i = 0; i < numberOfRepeats; i++)
            {
                result += template;
            }

            return result;
        }
    }
}
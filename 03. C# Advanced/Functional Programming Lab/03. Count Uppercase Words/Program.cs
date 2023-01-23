using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> startsWithCapital = w => char.IsUpper(w[0]);

            List<string> listWithCaps = new List<string>();

            Console.WriteLine(String.Join("\n", input.Where(startsWithCapital)));

            //                         Another way
            //foreach (var item in input)
            //{
            //    if (startsWithCapiral(item))
            //    {
            //        listWithCaps.Add(item);
            //    }    
            //}

            //foreach (var item in listWithCaps)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
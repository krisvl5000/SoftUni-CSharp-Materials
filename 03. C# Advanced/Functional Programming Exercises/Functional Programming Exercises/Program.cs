using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = x => Console.WriteLine(String.Join("\n", x));

            string[] names = Console.ReadLine().Split();
            print(names);
        }
    }
}
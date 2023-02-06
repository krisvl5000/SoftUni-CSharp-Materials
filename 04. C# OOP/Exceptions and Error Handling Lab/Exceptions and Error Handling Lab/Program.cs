using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Na kolko si?");
                    int n = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Nevalidni godini!");
                }
            }
            

            Console.WriteLine("After try catch");
        }
    }
}
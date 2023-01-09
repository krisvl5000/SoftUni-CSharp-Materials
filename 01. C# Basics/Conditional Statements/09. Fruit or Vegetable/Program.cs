using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            if ((product == "banana") || (product == "apple") || (product == "kiwi") || (product == "cherry") || (product == "lemon") || (product == "grapes"))
            {
                Console.WriteLine("fruit");
            }
            else if ((product == "tomato") || (product == "cucumber") || product == ("pepper") || (product == "carrot"))
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
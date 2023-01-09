using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
         string animal = Console.ReadLine();

            switch(animal)
            {
                case "dog":
                    Console.WriteLine("mammal");
                    break;

                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptile");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;

            }
             

        }
    }
}
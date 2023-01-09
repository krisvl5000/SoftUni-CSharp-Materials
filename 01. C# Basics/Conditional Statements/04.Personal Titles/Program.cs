using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();
           if (sex == "m")
            {
                if (age <16)
                {
                    Console.WriteLine("Master");
                }
                else
                    Console.WriteLine("Mr.");
            }
           else if (sex == "f")
            {
                if (age <16)
                {
                    Console.WriteLine("Miss");
                }
                else
                    Console.WriteLine("Ms.");
            }


        }
    }
}
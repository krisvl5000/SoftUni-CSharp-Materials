using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());



            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            for (int i = 1; i <= numbers; i++)
            {              
                int input = int.Parse(Console.ReadLine());
               
                if (input > maxNumber)
                {
                    maxNumber = input;
                }
                if (input < minNumber)
                {
                    minNumber = input;
                }
                    
            }
            
            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
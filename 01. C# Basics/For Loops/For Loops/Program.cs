using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("how many cool numbers do you want: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 1; i <= count; i++)
            {
                double result = Math.Pow(2, i);
                Console.WriteLine(result);
            }
            
            
        }
    }
    
}
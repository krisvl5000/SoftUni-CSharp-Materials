using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int even = 0;
            int odd = 0;

            for (int i = 1; i <= numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

               if (i % 2 == 0)
               {
                    even += number;
                   
               }
               else
               {
                    odd += number;
                    
               }               
            }

            int diff = Math.Abs(even - odd);

            if (even == odd)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {even}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
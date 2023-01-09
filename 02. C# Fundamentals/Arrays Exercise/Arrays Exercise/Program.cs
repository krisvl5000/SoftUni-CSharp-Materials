using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int totalSum = 0;

            int[] people = new int[count];

           // people = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = int.Parse(Console.ReadLine());

                totalSum += people[i];
                       
            }  
            
            Console.Write(string.Join(" ", people));

            Console.WriteLine();
            
            Console.WriteLine(totalSum);

        }
    }
}
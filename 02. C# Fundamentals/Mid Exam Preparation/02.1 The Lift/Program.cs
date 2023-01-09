using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool hasSpace = false;

            for (int i = 0; i < wagons.Length; i++)
            {
                while (wagons[i] <= 4) // macimum capacity
                {
                    if (people == 0)
                    {
                        break;
                    }

                    if (wagons[i] == 4)
                    {
                        break;
                    }

                    people--;
                    wagons[i]++;                   
                }

                if (people == 0)
                {
                    break;
                }
            }

            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < 4)
                {
                    hasSpace = true;
                }
            }

            if (hasSpace && people == 0)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if ((!hasSpace) && people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
            }

            Console.WriteLine($"{string.Join(" ", wagons)}");
        }
    }
}
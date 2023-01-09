using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            int[] bombInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int bombNumber = bombInfo[0];
            int bombPower = bombInfo[1];

            

            while (true)
            { 
                int indexOfBomb = numbers.IndexOf(bombNumber);

                if (indexOfBomb == - 1)
                {
                    break;
                }

                DetonateBomb(numbers, indexOfBomb, bombPower);
            }

            Console.WriteLine(numbers.Sum());
           

        static void DetonateBomb(List<int> numbers, int indexOfBomb, int bombPower)
        {
                int rightCount = indexOfBomb + bombPower;

                for (int cnt = indexOfBomb; cnt <= rightCount; cnt++)
                {
                    if (cnt < numbers.Count)
                    {
                        break;
                    }

                    numbers.RemoveAt(indexOfBomb);
                }

                int leftCount = indexOfBomb - bombPower;

                if (leftCount < 0)
                {
                    leftCount = 0;
                }

                for (int cnt = indexOfBomb; cnt < leftCount; cnt++)
                {
                    if (leftCount >= numbers.Count)
                    {
                        break;
                    }

                    numbers.RemoveAt(leftCount);
                }

            }
        }
    }
}
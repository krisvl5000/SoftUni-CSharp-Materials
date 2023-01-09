using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            double average = 0;

            foreach (var num in list)
            {
                average += num;
            }

            average /= list.Count;

            list.Sort();
            list.Reverse();

            List<int> nums5 = new List<int>();

            foreach (var num in list)
            {
                if (num > average)
                {
                    nums5.Add(num);
                }

                if (nums5.Count == 5)
                {
                    break;
                }
            }

            if (nums5.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(String.Join(" ", nums5));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" : ");

            while (input[0] != "end")
            {
                string courseName = input[0];
                string peopleName = input[1];

                if (!dict.ContainsKey(courseName))
                {
                    dict.Add(courseName, new List<string>());
                }

                dict[courseName].Add(peopleName);

                input = Console.ReadLine().Split(" : ");
            }

            foreach (var course in dict)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var person in course.Value)
                {
                    Console.WriteLine($"-- {person}");
                }
            }

        }
    }
}
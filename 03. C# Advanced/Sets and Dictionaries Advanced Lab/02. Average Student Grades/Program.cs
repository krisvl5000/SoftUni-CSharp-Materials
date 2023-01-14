using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<decimal>();
                    dict[name].Add(grade);
                }
                else
                {
                    dict[name].Add(grade);
                }
            }

            foreach (var student in dict)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():F2})");
            }

        }
    }
}
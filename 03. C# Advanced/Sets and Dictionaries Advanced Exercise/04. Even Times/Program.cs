using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, 0);
                }

                dict[input]++;
            }

            Console.WriteLine(dict.Where(x => x.Value % 2 == 0)
                .Select(y => y.Key).First());

        }
    }
}
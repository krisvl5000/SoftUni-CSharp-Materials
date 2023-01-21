using System;

namespace Box
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> list = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Box<string> box = new Box<string>(input);
                list.Add(box);
            }

            string element = Console.ReadLine();

            Console.WriteLine(Box<string>.HowManyAreGreater(list, element));
        }
    }
}
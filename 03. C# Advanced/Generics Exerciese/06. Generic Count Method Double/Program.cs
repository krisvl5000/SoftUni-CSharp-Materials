using System;

namespace Box
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> list = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                Box<double> box = new Box<double>(input);
                list.Add(box);
            }

            double element = double.Parse(Console.ReadLine());

            Console.WriteLine(Box<double>.HowManyAreGreater(list, element));
        }
    }
}
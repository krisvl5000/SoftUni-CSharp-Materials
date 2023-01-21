using System;

namespace Box
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = input[0] + " " + input[1];
            string address = input[2];

            Tuple<string, string> firstTuple = 
                new Tuple<string, string>(fullName, address);

            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(name, litersOfBeer);

            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int first = int.Parse(thirdInput[0]);
            double second = double.Parse(thirdInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(first, second);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
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
            string town = input[3];
            string secondTownHalf;

            if (input.Length == 5)
            {
                town = input[3] + " " + input[4];
            }

            Tuple<string, string, string> firstTuple =
                new Tuple<string, string, string>(fullName, address, town);

            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = secondInput[0];
            int litersOfBeer = int.Parse(secondInput[1]);
            bool isDrunk = false;
            string drunkState = secondInput[2];

            if (drunkState == "drunk")
            {
                isDrunk = true;
            }
            else if (drunkState == "not")
            {
                isDrunk = false;
            }

            Tuple<string, int, bool> secondTuple = 
                new Tuple<string, int, bool>(name, litersOfBeer, isDrunk);

            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string first = thirdInput[0];
            double second = double.Parse(thirdInput[1]);
            string third = thirdInput[2];

            Tuple<string, double, string> thirdTuple = 
                new Tuple<string, double, string>(first, second, third);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
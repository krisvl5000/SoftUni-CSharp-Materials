using System;
using System.Linq;
using System.Text;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var item in message)
            {
                sb.Append(item);
            }

            while (input[0] != "Travel")
            {
                string command = input[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(input[1]);
                    string newStop = input[2];

                    if (IsIndexValid(sb, index))
                    {
                        sb.Insert(index, newStop);
                    }

                    Console.WriteLine(sb.ToString());
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);

                    if (IsIndexValid(sb, startIndex, endIndex))
                    {
                        sb.Remove(startIndex, endIndex - startIndex + 1);
                    }

                    Console.WriteLine(sb.ToString());
                }
                else if (command == "Switch")
                {
                    string oldString = input[1];
                    string newString = input[2];

                    string test = sb.ToString();

                    if (test.Contains(oldString))
                    {
                        sb.Replace(oldString, newString);
                    }

                    Console.WriteLine(sb.ToString());
                }

                input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Ready for world tour! " +
                $"Planned stops: {sb}");

        }

        static bool IsIndexValid(StringBuilder message, int index)
        {
            return index >= 0 && index < message.Length;
        }

        static bool IsIndexValid(StringBuilder message, int startIndex, int endIndex)
        {
            return startIndex >= 0 && startIndex < message.Length
                && endIndex >= 0 && endIndex < message.Length
                && startIndex <= endIndex;
        }
    }
}
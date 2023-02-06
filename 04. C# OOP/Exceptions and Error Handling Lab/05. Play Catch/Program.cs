using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int exceptionCounter = 0;

            while (exceptionCounter < 3)
            {
                try
                {
                    string[] input = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = input[0];

                    if (command == "Replace")
                    {
                        int index = int.Parse(input[1]);
                        int element = int.Parse(input[2]);

                        arr[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int startIndex = int.Parse(input[1]);
                        int endIndex = int.Parse(input[2]);

                        List<int> elements = new List<int>();

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            elements.Add(arr[i]);
                        }

                        Console.WriteLine(String.Join(", ", elements));
                    }
                    else if (command == "Show")
                    {
                        int index = int.Parse(input[1]);

                        Console.WriteLine(arr[index]);
                    }
                }
                catch (IndexOutOfRangeException iofre)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCounter++;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCounter++;
                }
            }

            Console.WriteLine(String.Join(", ", arr));
        }
    }
}
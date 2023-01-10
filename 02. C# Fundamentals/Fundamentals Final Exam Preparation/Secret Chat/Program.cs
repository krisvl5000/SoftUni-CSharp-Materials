using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] input = Console.ReadLine().Split(":|:");

            while (input[0] != "Reveal")
            {
                string command = input[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(input[1]);

                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (command == "Reverse")
                {
                    string stringToChange = input[1];

                    if (message.Contains(stringToChange))
                    {
                        message = message.Remove(message
                            .IndexOf(stringToChange), stringToChange.Length);

                        string reverseString = string.Empty;

                        Stack<char> chars = new Stack<char>();
                        foreach (var item in stringToChange)
                        {
                            chars.Push(item);
                        }

                        foreach (var item in stringToChange)
                        {
                            reverseString += chars.Pop();
                        }

                        message += reverseString;

                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string stringToChange = input[1];
                    string replacement = input[2];

                    message = message.Replace(stringToChange, replacement);

                    Console.WriteLine(message);
                }

                input = Console.ReadLine().Split(":|:");
            }

            Console.WriteLine($"You have a new text message: {message}");

        }
    }
}
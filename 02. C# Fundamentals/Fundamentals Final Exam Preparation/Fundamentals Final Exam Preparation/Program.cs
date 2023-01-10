using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Decode")
            {
                string command = input[0];

                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(input[1]);
                    string substring = message.Substring(0, numberOfLetters);

                    message = message.Replace(substring, "");
                    message += substring;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(input[1]);
                    string value = input[2];

                    message = message.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string subToReplace = input[1];
                    string replacement = input[2];

                    message = message.Replace(subToReplace, replacement);
                }

                input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The decrypted message is: {message}");

        }
    }
}
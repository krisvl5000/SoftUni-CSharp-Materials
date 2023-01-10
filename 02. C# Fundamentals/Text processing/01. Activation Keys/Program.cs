using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace My_New_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] commandParams = command.Split(">>>",
                    StringSplitOptions.RemoveEmptyEntries);

                string action = commandParams[0];

                if (action == "Contains")
                {
                    string wordToSearchFor = commandParams[1];

                    if (rawActivationKey.Contains(wordToSearchFor))
                    {
                        Console.WriteLine($"{rawActivationKey} contains " +
                            $"{wordToSearchFor}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (action == "Flip")
                {
                    string caseToFlip = commandParams[1];
                    int startIndex = int.Parse(commandParams[2]);
                    int endIndex = int.Parse(commandParams[3]);

                    string textToFlip = rawActivationKey.Substring(startIndex,
                        endIndex - startIndex);

                    if (caseToFlip == "Lower")
                    {
                        textToFlip = textToFlip.ToLower();
                    }
                    else
                    {
                        textToFlip = textToFlip.ToUpper();
                    }

                    rawActivationKey = rawActivationKey
                        .Remove(startIndex, endIndex - startIndex);

                    rawActivationKey = rawActivationKey
                        .Insert(startIndex, textToFlip);

                    Console.WriteLine(rawActivationKey);
                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(commandParams[1]);
                    int endIndex = int.Parse(commandParams[2]);

                    rawActivationKey = rawActivationKey
                        .Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(rawActivationKey);
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");

        }
    }
}
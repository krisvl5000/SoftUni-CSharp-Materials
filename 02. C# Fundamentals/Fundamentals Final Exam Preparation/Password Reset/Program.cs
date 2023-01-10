using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "Done")
            {
                string command = input[0];

                if (command == "TakeOdd")
                {
                    string newPassword = string.Empty;

                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 == 1)
                        {
                            newPassword += password[i];
                        }
                    }

                    password = newPassword;
                    Console.WriteLine(password);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(input[1]);
                    int length = int.Parse(input[2]);

                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (command == "Substitute")
                {
                    string substring = input[1];
                    string substitute = input[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine($"Your password is: {password}");

        }
    }
}
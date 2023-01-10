using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipSet = new HashSet<string>();
            HashSet<string> regularSet = new HashSet<string>();


            string input = Console.ReadLine();
            
            bool gameIsOver = false;

            while (true)
            {

                if (input == "PARTY")
                {
                    input = Console.ReadLine();

                    while (true)
                    {
                        vipSet.Remove(input);
                        regularSet.Remove(input);

                        if (input == "END")
                        {
                            gameIsOver = true;
                            break;
                        }

                        input = Console.ReadLine();
                    }
                }

                if (gameIsOver)
                {
                    break;
                }

                if (input == "END")
                {
                    break;
                }

                string number = input;

                foreach (var item in number)
                {
                    if (char.IsDigit(item))
                    {
                        vipSet.Add(number);
                    }
                    else
                    {
                        regularSet.Add(number);
                    }

                    break;
                }

                input = Console.ReadLine();
            }

            int totalCount = vipSet.Count + regularSet.Count;
            Console.WriteLine(totalCount);

            foreach (var item in vipSet)
            {
                Console.WriteLine(item);
            }

            foreach (var item in regularSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}

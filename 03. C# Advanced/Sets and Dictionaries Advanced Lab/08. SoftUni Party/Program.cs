using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipSet = new HashSet<string>();
            HashSet<string> regSet = new HashSet<string>();

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "PARTY")
                {
                    string peopleWhoCame = Console.ReadLine();

                    while (true)
                    {
                        if (peopleWhoCame == "END")
                        {
                            input = "END";
                            break;
                        }

                        if (vipSet.Contains(peopleWhoCame))
                        {
                            vipSet.Remove(peopleWhoCame);
                        }
                        else if (regSet.Contains(peopleWhoCame))
                        {
                            regSet.Remove(peopleWhoCame);
                        }

                        peopleWhoCame = Console.ReadLine();
                    }
                }

                if (input == "END")
                {
                    break;
                }

                if (char.IsDigit(input.First()))
                {
                    vipSet.Add(input);
                }
                else
                {
                    regSet.Add(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(vipSet.Count + regSet.Count);

            foreach (var item in vipSet)
            {
                Console.WriteLine(item);
            }

            foreach (var item in regSet)
            {
                Console.WriteLine(item);
            }
            

        }
    }
}
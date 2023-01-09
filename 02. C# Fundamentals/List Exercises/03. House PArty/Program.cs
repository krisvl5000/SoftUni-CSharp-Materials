using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            string[] input;

            for (int i = 1; i <= n; i++)
            {
                input = Console.ReadLine().Split().ToArray();

                string name = input[0];

                if (!list.Contains(name) && input[2] != "not")
                {
                    list.Add(name);
                }
                else if (list.Contains(name) && input[2] != "not")
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else if (list.Contains(name) && input[2] == "not")
                {
                    list.Remove(name);
                }
                else if (!list.Contains(name) && input[2] == "not")
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
                
                
            }
            
            Console.WriteLine(String.Join("\n", list));

        }
    }
}
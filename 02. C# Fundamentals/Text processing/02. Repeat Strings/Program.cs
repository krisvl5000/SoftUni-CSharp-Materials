using System;
using System.Text;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            StringBuilder sb = new StringBuilder();

            foreach (var word in arr)
            {
                foreach (char ch in word)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb.ToString());
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stringToReverse;

            

            while ((stringToReverse = Console.ReadLine()) != "end")
            {
                StringBuilder sb = new StringBuilder();

                for (int i = stringToReverse.Length - 1; i >= 0; i--)
                {
                    sb.Append(stringToReverse[i]);
                }

                Console.WriteLine($"{stringToReverse} = {sb}");
            }

        }
    }
}
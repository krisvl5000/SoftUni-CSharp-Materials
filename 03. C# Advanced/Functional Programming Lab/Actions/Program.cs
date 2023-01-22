using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // You can use Action for void methods

            Action<int, string, object, decimal> strangeFunction = StrangeFunc;

        }
        static void StrangeFunc(int x, string y, object z, decimal xx)
        {
            Console.WriteLine("Strange Function called");
        }
    }
}
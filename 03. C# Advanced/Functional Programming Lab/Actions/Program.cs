using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // You can use Action for void methods

            var list = new List<int>() { 1, 2, 3, 4, 5 };

            Iterate(list, x => Console.WriteLine(x));
        }
        static void Iterate(List<int> list, Action<int> callback)
        {
            foreach (var item in list)
            {
                callback(item);
            }
        }
    }
}
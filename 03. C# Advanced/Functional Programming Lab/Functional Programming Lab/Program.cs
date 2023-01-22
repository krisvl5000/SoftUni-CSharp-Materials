using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //We can create variables holding entire methods, but we need to
            //define the method we are going to use
            //Func<int, int, int> multiplier = Multiply;
            //Console.WriteLine(multiplier(5, 6));
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }

        static Func<int, int, int> GetMethod(string input)
        {

        }
    }
}
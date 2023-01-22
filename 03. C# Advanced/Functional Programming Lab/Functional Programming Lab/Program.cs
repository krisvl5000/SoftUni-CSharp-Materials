using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We can create variables holding entire methods, but we need to
            // define the method we are going to use..

            // The first data type is the one it is going to be returning,
            // and all the ones before that are the types of parameters passed

            //Func<int, int, int> multiplier = Multiply;
            //Console.WriteLine(multiplier(5, 6));

            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            string sign = Console.ReadLine();
            Func<int, int, int> calcMethod = GetCalcMethod(sign);

            Console.WriteLine(calcMethod(x, y));

            
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }
        static int Subtract(int x, int y)
        {
            return x - y;
        }
        static int Sum(int x, int y)
        {
            return x + y;
        }

        static Func<int, int, int> GetCalcMethod(string input)
        {
            switch (input)
            {
                case "*":
                    return Multiply;
                case "-":
                    return Subtract;
                case "+":
                    return Sum;
                default:
                    return null;
            }
        }
    }
}
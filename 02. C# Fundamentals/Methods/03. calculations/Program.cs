using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = Console.ReadLine();

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (action == "add")
            {
                Add(num1, num2);
            }
            else if (action == "multiply")
            {
                Multiply(num1, num2);
            }
            else if (action == "substract")
            {
                Substract(num1, num2);
            }
            else if (action == "divide")
            {
                Divide(num1, num2);
            }

        }

        static void Add(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine(result);
        }

        static void Multiply(int num1, int num2)
        {
            int result = num1 * num2;
            Console.WriteLine(result);
        }

        static void Substract(int num1, int num2)
        {
            int result = num1 - num2;
            Console.WriteLine(result);
        }

        static void Divide(int num1, int num2)
        {
            int result = num1 / num2;
            Console.WriteLine(result);
        }
    }
}
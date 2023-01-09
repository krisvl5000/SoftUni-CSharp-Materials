using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());

            if (@operator == "/")
            {
                Console.WriteLine(Division(num1, num2));
            }
            else if (@operator == "*")
            {
                Console.WriteLine(Multiplication(num1, num2));
            }
            else if (@operator == "+")
            {
                Console.WriteLine(Addition(num1, num2));
            }
            else if (@operator == "-")
            {
                Console.WriteLine(Substraction(num1, num2));
            }

        }

        static int Division(int num1, int num2)
        {
            int result = num1 / num2;
            return result;
        }
        static int Multiplication(int num1, int num2)
        {
            int result = num1 * num2;
            return result;
        }
        static int Addition(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }
        static int Substraction(int num1, int num2)
        {
            int result = num1 - num2;
            return result;
        }
    }
}
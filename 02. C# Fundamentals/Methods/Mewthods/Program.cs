using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = int.Parse(Console.ReadLine());
            char action = Convert.ToChar(Console.ReadLine());
            double num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(Math(num1, action, num2));

        }

        static double Math(double num1, char action, double num2)
        {
            double result = 0;
            
            if (action == '/')
            {
                result = num1 / num2;
            }
            else if (action == '*')
            {
                result = num1 * num2;
            }
            else if (action == '+')
            {
                result = num1 + num2;
            }
            else
            {
                result = num1 - num2;
            }

            return result;
        }
    }
}
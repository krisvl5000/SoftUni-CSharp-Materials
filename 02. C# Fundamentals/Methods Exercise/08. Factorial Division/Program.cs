using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int firstNumFactorial = FirstNumFactorial(firstNum);
            int secondNumFactorial = SecondNumFactorial(secondNum);

            Console.WriteLine($"{firstNumFactorial / secondNumFactorial:F2}");

        }

        static int FirstNumFactorial(int firstNum)
        {
            int firstNumFactorial = 1;

            for (int i = firstNum; i >= 1; i--)
            {
                firstNumFactorial *= i;
            }

            return firstNumFactorial;
        }

        static int SecondNumFactorial(int secondNum)
        {
            if (secondNum != 0)
            {
                int secondNumFactorial = 1;

                for (int i = secondNum; i >= 1; i--)
                {
                    secondNumFactorial *= i;
                }

                return secondNumFactorial;
            }

            return 0;

        }
    }
}
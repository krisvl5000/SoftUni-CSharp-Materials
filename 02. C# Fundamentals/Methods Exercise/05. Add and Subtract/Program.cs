using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int result = Sum(firstNum, secondNum);
            int finalSum = FinalSum(result, thirdNum);

            Console.WriteLine(finalSum);

        }

        static int Sum(int firstNum, int secondNum)
        {
            int result = firstNum + secondNum;
            return result;
        }

        static int FinalSum(int result, int thirdNum)
        {
            int finalSum = result - thirdNum;
            return finalSum;
        }
    }
}
using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = width;

            for (int j = 0; j < width; j++)
            {
                Console.Write($"{height} ");

                Inner(height, width);

                Console.WriteLine();
            }

        }

        static void Inner(int height, int width)
        {
            for (int i = 1; i < height; i++)
            {
                Console.Write($"{width} ");
            }


        }
    }
}
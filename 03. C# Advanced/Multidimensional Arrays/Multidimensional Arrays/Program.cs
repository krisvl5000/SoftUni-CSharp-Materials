using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[2, 3];
            // frist number are the rows, second number are the columns
            // when creating, you can add more comas to increase the dimensions

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;

            Console.Write($"{matrix[0, 0]} ");
            Console.Write($"{matrix[0, 1]} ");
            Console.Write($"{matrix[0, 2]} ");

            Console.WriteLine();
                                               
            Console.Write($"{matrix[1, 0]} ");
            Console.Write($"{matrix[1, 1]} ");
            Console.Write($"{matrix[1, 2]} ");

            Console.WriteLine();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            //                             Jagged Arrays


            Console.WriteLine("How many rows?");

            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine("How many cols?");
                int cols = int.Parse(Console.ReadLine());
                jaggedArray[row] = new int[cols];

                for (int col = 0; col < cols; col++)
                {
                    jaggedArray[row][col] = int.Parse(Console.ReadLine());
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
            


        }
    }
}
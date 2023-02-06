using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

        }

        static void ReadNumber(int start, int end)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                if (n < start || n > end)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}
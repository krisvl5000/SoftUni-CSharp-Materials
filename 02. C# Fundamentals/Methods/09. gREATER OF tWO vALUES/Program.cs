using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(num1, num2));
            }
            else if (type == "char")
            {
                char char1 = Convert.ToChar(Console.ReadLine());
                char char2 = Convert.ToChar(Console.ReadLine());

                Console.WriteLine(GetMax(char1, char2));
            }
            else if (type == "string")
            {
                string string1 = Console.ReadLine();
                string string2 = Console.ReadLine();

                Console.WriteLine(GetMax(string1, string2));
            }

        }

        static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        static char GetMax(char char1, char char2)
        {
            if (char1 > char2)
            {
                return char1;
            }
            else
            {
                return char2;
            }
           
        }

        static string GetMax(string string1, string string2)
        {
            if (string1.CompareTo(string2) > 0)
            {
                return string1;
            }
            else
            {
                return string2;
            }
        }
    }
}
﻿using System;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            
            for(int position = 0; position <= text.Length - 1; position++)
            {
                char symbol = text[position];
                Console.WriteLine(symbol);
            }

        }
    }
}
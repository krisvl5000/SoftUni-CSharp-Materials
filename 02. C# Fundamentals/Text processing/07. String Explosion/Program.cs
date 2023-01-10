using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_New_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder outputText = new StringBuilder();

            string inputText = Console.ReadLine();

            int bombPower = 0;

            for (int i = 0; i < inputText.Length; i++)
            {
                char currChar = inputText[i];

                if (currChar == '>')
                {
                    outputText.Append(currChar);

                    bombPower += GetCurrentBombPower(inputText[i + 1]);
                }
                else
                {
                    if (bombPower > 0)
                    {
                        bombPower--;
                    }
                    else
                    {
                        outputText.Append(currChar);
                    }
                }
            }

            Console.WriteLine(outputText.ToString());
            
        }

        static int GetCurrentBombPower(char ch)
        {
            return (int)ch - 48;
        }
    }
}
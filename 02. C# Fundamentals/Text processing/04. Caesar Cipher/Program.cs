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
            const int SHIFT = 3;

            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (var ch in text)
            {
                char newCh = (char)(ch + SHIFT);

                sb.Append(newCh);
            }

            Console.WriteLine(sb.ToString());
            
        }
    }
}
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
            StringBuilder sb = new StringBuilder();

            sb.Append(Console.ReadLine());

            int index = 0;

            while (index < sb.Length - 1)
            {
                if (sb[index] == sb[index + 1])
                {
                    sb.Remove(index + 1, 1);
                }
                else
                {
                    index++;
                }
            }

            Console.WriteLine(sb);

        }
    }
}
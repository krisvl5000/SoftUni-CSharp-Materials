using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace My_New_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rawUsernames = Console.ReadLine().Split(", ");

            foreach (var name in rawUsernames)
            {
                if (name.Length >= 3 && name.Length <= 16)
                {
                    bool isValid = true;
                    foreach (var ch in name)
                    {                        
                        if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '_')
                        {
                            isValid = false;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(name);
                    }
                }
            }
            
        }
    }
}
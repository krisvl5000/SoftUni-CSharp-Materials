using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Common
{
    public class Logger : ILogger
    {
        public Logger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A new Logger instance was created!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Log(string message)
        {
            Console.WriteLine($"Logging {message}");
        }
    }
}

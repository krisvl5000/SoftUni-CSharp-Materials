using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}

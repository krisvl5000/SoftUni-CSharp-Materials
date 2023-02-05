using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object text)
        {
            Console.Write(text.ToString());
        }

        public void WriteLine(object text)
        {
            Console.WriteLine(text.ToString());
        }
    }
}

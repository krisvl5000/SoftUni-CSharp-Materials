using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Renderers
{
    public class ConsoleRenderer : IRenderer
    {
        public void Write(object obj)
        {
            Console.Write(obj);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}

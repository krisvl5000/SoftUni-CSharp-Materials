using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public abstract class Printer
    {
        public int Color { get; set; }

        public int Size { get; set; }

        public abstract void Print();

        public void Clean()
        {
            Console.WriteLine("Clean printer");
        }
    }
}

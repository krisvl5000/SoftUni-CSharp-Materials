using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public class ThreeDPrinter : Printer
    {
        public override void Print()
        {
            Console.WriteLine("Printing in 3d");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public class PaperPrinter : Printer
    {
        public override void Print()
        {
            Console.WriteLine("Printing to paper");
        }
    }
}

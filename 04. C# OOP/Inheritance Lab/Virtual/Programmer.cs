using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual
{
    public class Programmer : Employee
    {
        public override void Work()
        {
            base.Work();
            Console.WriteLine("Programistite ne rabotqt!!!");
        }
    }
}

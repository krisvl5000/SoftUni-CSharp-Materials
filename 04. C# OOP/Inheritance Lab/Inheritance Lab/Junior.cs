using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Junior : Programmer
    {
        public Junior(string name) : base(name)
        {
            Console.WriteLine($"In Junior constructor with the name {name}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Programmer : Employee
    {
        public Programmer(string name) : base(name)
        {
            Console.WriteLine($"In programmer constructor with the name {name}");
        }

        public void CreateBugs()
        {
            Console.WriteLine("Sometimes I create  bugs");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual
{
    public class Employee
    {
        public decimal Salary { get; set; }

        public string Name { get; set; }

        public virtual void Work() // virtual means that that it can be overridden, and is even
            // expected to be. You can also use the keyword "sealed" to prevent the class
            // or method from being inherited.
        {
            Console.WriteLine("Gore - dolu bachkam, gledam i da si pochivam");
        }

        public override string ToString()
        {
            return $"Nashiq si ToString";
        }
    }
}

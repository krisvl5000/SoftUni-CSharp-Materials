using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person peter = new Person("Peter", 20);
            Person george = new Person("George", 18);
            Person jose = new Person("Jose", 43);
        }
    }
}
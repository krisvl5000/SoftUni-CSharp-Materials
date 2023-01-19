using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefiningClasses;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person peter = new Person("Peter", 20);
            peter.Name = "Peter";
            peter.Age = 20;

            Person george = new Person("George", 18);
            george.Name = "George";
            george.Age = 18;

            Person jose = new Person("Jose", 43);
            jose.Name = "Jose";
            jose.Age = 43;
        }
    }
}
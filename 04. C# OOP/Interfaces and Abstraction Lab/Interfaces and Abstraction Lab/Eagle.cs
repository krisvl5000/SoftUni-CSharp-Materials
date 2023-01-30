using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterfaces
{
    public class Eagle : Animal
    {
        public Eagle() : base(FoodType.Oats, 10)
        {

        }

        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }
}

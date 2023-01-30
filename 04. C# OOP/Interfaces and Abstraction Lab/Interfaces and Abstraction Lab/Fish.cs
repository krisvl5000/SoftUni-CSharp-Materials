using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterfaces
{
    public class Fish : Animal
    {
        public Fish() : base(FoodType.Wheat, 5)
        {

        }

        public void Swim()
        {
            //Console.WriteLine("Swimming");
        }
    }
}

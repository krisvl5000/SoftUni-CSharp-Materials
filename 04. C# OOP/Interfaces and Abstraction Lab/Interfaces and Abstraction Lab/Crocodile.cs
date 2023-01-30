using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterfaces
{
    public class Crocodile : Animal
    {
        public Crocodile() : base(FoodType.Meat, 15)
        {

        }

        public override void Eat()
        {
            Console.WriteLine("Eating everything");
        }

        public void ScarePeople()
        {
            Console.WriteLine("Pa");
        }
    }
}

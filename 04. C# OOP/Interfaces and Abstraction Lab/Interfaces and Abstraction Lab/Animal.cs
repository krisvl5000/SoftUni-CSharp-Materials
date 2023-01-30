using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterfaces
{
    public class Animal : IFeedable
    {
        public Animal(FoodType type, int dose)
        {
            FoodType = type;
            Dose = dose;
        }

        public FoodType FoodType { get; set; }

        public int Dose { get; set; }

        public virtual void Eat()
        {
            Console.WriteLine("I am eating");
        }

        public void Sleep()
        {
            Console.WriteLine("i am sleeping");
        }

        public void Play()
        {
            Console.WriteLine("Playing");
        }
    }
}

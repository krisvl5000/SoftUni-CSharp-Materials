using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterfaces
{
    public class Caretaker
    {
        public void Feed(Animal animal)
        {
            Console.WriteLine($"Get {animal.Dose} {animal.FoodType} from inventory");
            Console.WriteLine("Feeding animal");
            animal.Eat();
        }
    }
}

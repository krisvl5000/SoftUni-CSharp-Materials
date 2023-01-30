using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterfaces
{
    public class Caretaker
    {
        public void Feed(IFeedable feedable)
        {
            Console.WriteLine($"Get {feedable.Dose} {feedable.FoodType} from inventory");
            Console.WriteLine("Feeding animal");
            feedable.Eat();
        }
    }
}

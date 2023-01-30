using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterfaces
{
    public class Baby : IFeedable
    {
        public int Dose { get; set; }

        public FoodType FoodType { get; set; }

        public void Eat()
        {
            Console.WriteLine("Mryn");
        }
    }
}

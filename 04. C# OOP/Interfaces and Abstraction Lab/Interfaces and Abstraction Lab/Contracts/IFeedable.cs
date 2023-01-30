using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterfaces
{
    public interface IFeedable
    {
        void Eat();

        public int Dose { get; set; }

        public FoodType FoodType { get; set; }
    }
}

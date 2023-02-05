using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public interface IFoodFactory
    {
        IFood CreateFood(string type, int quantity);
    }
}

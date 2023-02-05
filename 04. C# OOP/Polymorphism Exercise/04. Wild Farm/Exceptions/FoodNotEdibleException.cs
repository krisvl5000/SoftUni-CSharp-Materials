using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class FoodNotEdibleException : Exception
    {
        public FoodNotEdibleException(string message) : base(message)
        {

        }
    }
}

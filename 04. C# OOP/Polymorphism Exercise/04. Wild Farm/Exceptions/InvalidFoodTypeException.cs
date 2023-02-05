using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class InvalidFoodTypeException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid food type!";
        public InvalidFoodTypeException() : base(DEFAULT_MESSAGE)
        {

        }

        public InvalidFoodTypeException(string message) : base(message)
        {

        }
    }
}

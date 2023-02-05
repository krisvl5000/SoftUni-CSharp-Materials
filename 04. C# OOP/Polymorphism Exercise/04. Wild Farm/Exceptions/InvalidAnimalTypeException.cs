using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class InvalidAnimalTypeException : Exception
    {
        private const string DEFAULT_MESSAGE = "invalid animal type!";

        public InvalidAnimalTypeException() : base(DEFAULT_MESSAGE)
        {

        }

        public InvalidAnimalTypeException(string message) : base(message)
        {

        }
    }
}

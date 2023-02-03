using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class TooMuchFuelException : Exception
    {
        public const string DEFAULT_MESSAGE = "Cannot fill {0} fuel in the tank";

        public TooMuchFuelException()
        {

        }

        public TooMuchFuelException(string message) : base()
        {

        }
    }
}

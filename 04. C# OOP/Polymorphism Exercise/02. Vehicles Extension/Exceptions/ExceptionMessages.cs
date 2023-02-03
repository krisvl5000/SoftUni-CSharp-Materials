using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public static class ExceptionMessages
    {
        public const string INSUFFICIENT_FUEL_EXCEPTION_MESSAGE = 
            "{0} needs refueling";

        public const string TOO_MUCH_FUEL_EXCEPTION_MESSAGE = 
            "Cannot fill {0} fuel in the tank";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class InvalidVehicleTypeException : Exception
    {
        private const string DEFAULT_MESSAGE = "Vehicle type not supported!";
        public InvalidVehicleTypeException() : base(DEFAULT_MESSAGE)
        {

        }

        public InvalidVehicleTypeException(string message) : base(message)
        {

        }
    }
}

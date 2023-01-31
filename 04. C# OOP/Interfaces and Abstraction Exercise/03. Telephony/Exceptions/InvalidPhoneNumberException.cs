using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE =
            "Invalid number!";

        public InvalidPhoneNumberException() : base(DEFAULT_EXCEPTION_MESSAGE)
        {

        }

        public InvalidPhoneNumberException(string message) : base(message)
        {

        }
    }
}

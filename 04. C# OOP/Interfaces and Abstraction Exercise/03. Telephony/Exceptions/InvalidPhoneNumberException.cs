using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string INVALID_NUMBER_EXCEPTION = "Invalid number!";

        public InvalidPhoneNumberException() : base(INVALID_NUMBER_EXCEPTION)
        {

        }

        public InvalidPhoneNumberException(string message) : base(message)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Models
{
    using Interfaces;
    using Exceptions;
    public class Smartphone : ISmartphone
    {
        public Smartphone()
        {
            
        }

        public string BrowseURL(string url)
        {
            if (!ValidateURL(url))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}";
        }

        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
            => phoneNumber.All(x => char.IsDigit(x));

        private bool ValidateURL(string url)
            => url.All(x => !char.IsDigit(x));   
    }
}

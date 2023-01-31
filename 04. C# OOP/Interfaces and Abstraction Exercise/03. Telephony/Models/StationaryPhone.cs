﻿namespace Telephony.Models
{
    using Interfaces;
    using Exceptions;
    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone()
        {

        }

        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
            => phoneNumber.All(x => char.IsDigit(x));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public interface IStationaryPhone
    {
        string Call(string phoneNumber);
    }
}

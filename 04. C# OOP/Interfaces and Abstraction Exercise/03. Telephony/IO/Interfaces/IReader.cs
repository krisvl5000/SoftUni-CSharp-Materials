using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.IO.Interfaces
{
    public interface IReader
    {
        // Does not necessarily refer to the console
        // It can be the console, but also can be file.ReadLine
        string ReadLine();
    }
}

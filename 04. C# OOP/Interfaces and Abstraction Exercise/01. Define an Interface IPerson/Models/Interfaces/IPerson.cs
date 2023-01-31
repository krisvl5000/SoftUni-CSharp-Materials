using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo.Models.Interfaces
{
    public interface IPerson
    {
        string Name { get; } // We write no setters to encapsulate it better

        int Age { get; }
    }
}

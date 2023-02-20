using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Mission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        string CodeName { get; set; }

        public string State { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Mission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        string CodeName { get; set; }

        public string State
        {
            get { return State; }

            set
            {
                if (state == "inProgress" || state == "Finished")
                {
                    state = value;
                }

                return;
            }
        }
    }
}

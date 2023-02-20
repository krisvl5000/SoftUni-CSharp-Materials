using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Soldier : ISoldier
    {
        public Soldier()
        {

        }

        public Soldier(string id, string firstName, string lastName) : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; set; }

        public string FirstName {get; set; }

        public string LastName {get; set; }
    }
}

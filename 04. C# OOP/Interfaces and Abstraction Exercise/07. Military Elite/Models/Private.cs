using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private( string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public decimal Salary { get; set; }
    }
}

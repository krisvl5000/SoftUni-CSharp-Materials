using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName,
            decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            repairs = new HashSet<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs
            => (IReadOnlyCollection<IRepair>)repairs;
    }
}

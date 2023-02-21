using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName,
            decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new HashSet<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions
            => (IReadOnlyCollection<IMission>)missions;
    }
}

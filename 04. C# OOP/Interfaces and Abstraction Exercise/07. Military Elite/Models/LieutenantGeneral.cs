using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class LieutenantGeneral : SpecialisedSoldier, ILieutenantGeneral
    {
        private readonly ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, 
            string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            privates = new HashSet<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates
            => (IReadOnlyCollection<IPrivate>)privates;
    }
}

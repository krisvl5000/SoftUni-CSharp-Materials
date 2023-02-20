using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Commando : Soldier, ICommando
    {
        public Commando(string corps)
        {
            Corps = corps;
            Missions = new List<Mission>();
        }

        public ICollection<Mission> Missions { get; set; }

        public string Corps {get; set; }

        public void CompleteMission()
        {
            throw new NotImplementedException();
        }
    }
}

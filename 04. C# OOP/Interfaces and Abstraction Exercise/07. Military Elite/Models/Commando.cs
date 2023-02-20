using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Commando : Soldier, ICommando
    {
        private string corps;

        public Commando(string corps)
        {
            Corps = corps;
            Missions = new List<Mission>();
        }

        public ICollection<Mission> Missions { get; set; }

        public string Corps
        {
            get { return corps; }

            set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    corps = value;
                }

                return;
            }
        }

        public void CompleteMission()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Engineer : Soldier, IEngineer
    {
        private string corps;

        public Engineer(string corps)
        {
            Corps = corps;
            RepairList = new List<Repair>();
        }

        public ICollection<Repair> RepairList {get; set;}

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
    }
}

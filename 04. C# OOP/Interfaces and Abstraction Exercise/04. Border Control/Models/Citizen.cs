using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : ICitizen
    {
        public string Name {get; set;}

        public int Age {get; set;}

        public int Id { get; set;}
    }
}

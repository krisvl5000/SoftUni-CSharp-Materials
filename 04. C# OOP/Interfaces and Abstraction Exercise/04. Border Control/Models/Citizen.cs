using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : ICitizen
    {
        public Citizen()
        {

        }

        public Citizen(string name, int age, int id) : this()
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name {get; set;}

        public int Age {get; set;}

        public int Id { get; set;}
    }
}

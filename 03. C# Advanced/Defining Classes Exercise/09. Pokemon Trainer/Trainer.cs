using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> list;

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
        }
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> List { get; set; } = new List<Pokemon>();

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.List.Count}";
        }
    }
}

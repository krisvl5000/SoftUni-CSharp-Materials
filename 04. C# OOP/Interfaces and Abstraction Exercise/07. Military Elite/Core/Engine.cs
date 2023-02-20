using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        private readonly ICollection<ISoldier> soldiers;

        public Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public Engine(IWriter writer, IReader reader) : this()
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                ISoldier soldier = null;

                string input = reader.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] args = input.Split(' ');

                string id = args[1];
                string firstName = args[2];
                string lastName = args[3];
                decimal salary = decimal.Parse(args[4]);

                if (args[0] == "Private")
                {
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (args[0] == "Commando")
                {
                    string corps = args[5];
                    soldier = new Commando(firstName);

                }

                soldiers.Add(soldier);
            }

        }
    }
}

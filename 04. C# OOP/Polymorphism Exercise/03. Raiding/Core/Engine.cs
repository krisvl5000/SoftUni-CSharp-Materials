using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IBaseHero> heroes;

        public Engine()
        {
            this.heroes = new HashSet<IBaseHero>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (InvalidHeroTypeException ihte)
                {
                    writer.WriteLine(ihte.Message);
                }
                catch
                {
                    throw;
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
            int totalPower = 0;

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }

            if (totalPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private void ProcessCommand()
        {
            string name = reader.ReadLine();
            string type = reader.ReadLine();

            IBaseHero hero = null;

            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidHeroTypeException(string
                    .Format(ExceptionMessages.INVALID_HERO_MESSAGE));
            }

            heroes.Add(hero);
        }
    }
}

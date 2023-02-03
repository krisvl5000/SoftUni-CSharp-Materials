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
                string name = reader.ReadLine();
                string type = reader.ReadLine();
            }
        }
    }
}

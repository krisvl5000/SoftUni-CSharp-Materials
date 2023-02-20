using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICitizen citizen;
        private readonly IRobot robot;

        private ICollection<IEntity> list;

        private Engine()
        {
            this.citizen = new Citizen();
            this.robot = new Robot();

            this.list = new List<IEntity>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] args = input.Split(' ');

                IEntity entity = null;

                if (args.Length == 2)
                {
                    string model = args[0];
                    string id = args[1];

                    entity = new Robot(model, id);
                }
                else if (args.Length == 3)
                {
                    string name = args[0];
                    int age = int.Parse(args[1]);
                    string id = args[2];

                    entity = new Citizen(name, age, id);
                }

                list.Add(entity);
            }

            string fakeIdSequence = reader.ReadLine();

            foreach (var entity in list)
            {
                if (entity.Id.EndsWith(fakeIdSequence))
                {
                    writer.WriteLine(entity.Id);
                }
            }
        }
    }
}

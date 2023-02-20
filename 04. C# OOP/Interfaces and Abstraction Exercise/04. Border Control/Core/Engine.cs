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

        public Engine()
        {
            this.citizen = new Citizen();
            this.robot = new Robot();
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

                if (args.Length == 2)
                {
                    string model = args[0];
                    int id = int.Parse(args[1]);

                    IRobot robot = new Robot(model, id);
                }
                else if (args.Length == 3)
                {
                    string name = args[0];
                    int age = int.Parse(args[1]);
                    int id = int.Parse(args[2]);

                    ICitizen citizen = new Citizen(name, age, id);
                }
            }
        }
    }
}

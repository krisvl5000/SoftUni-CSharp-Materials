using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != nameof(HappyBunny) && bunnyType != nameof(SleepyBunny))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidBunnyType));
            }

            IBunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }

            bunnies.Add(bunny);

            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var dye = new Dye(power);

            var bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentBunny));
            }

            bunny.AddDye(dye);

            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            eggs.Add(new Egg(eggName, energyRequired));
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var bunniesReady = bunnies.Models.OrderByDescending(x => x.Energy >= 50).ToList();

            if (!bunniesReady.Any())
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.BunniesNotReady));
            }

            var egg = eggs.FindByName(eggName);

            var workshop = new Workshop();

            foreach (var bunny in bunniesReady)
            {
                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
            }

            if (egg.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone, eggName);
            }

            return String.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Count(x => x.IsDone())} eggs are done!");
            sb.Append($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine();
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.Append($"Dyes: {bunny.Dyes.Count(x => !x.IsFinished())} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

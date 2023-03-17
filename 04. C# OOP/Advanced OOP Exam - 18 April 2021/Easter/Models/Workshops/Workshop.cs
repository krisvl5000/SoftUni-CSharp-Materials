using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }

        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone() && bunny.Energy > 0 && bunny.Dyes.Any(x => x.IsFinished() == false))
            {
                var dye = bunny.Dyes.FirstOrDefault(x => !x.IsFinished());
                dye.Use();
                bunny.Work();
                egg.GetColored();
            }

        }
    }
}

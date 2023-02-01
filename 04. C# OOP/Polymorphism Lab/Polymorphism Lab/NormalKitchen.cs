using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class NormalKitchen : Kitchen
    {
        public override void CleanKitchen()
        {
            Console.WriteLine("Normal Kitchen: izmii spokoino");
        }

        public override void CookMeat()
        {
            Console.WriteLine("Normal Kitchen: sgotvi mesoto");
        }

        public override void CookVegetarian()
        {
            Console.WriteLine("Normal Kitchen: eto salata");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class OldKitchen : Kitchen
    {
        public override void CleanKitchen()
        {
            Console.WriteLine("Old Kitchen: izhvurli vsichko i izmii");
        }

        public override void CookMeat()
        {
            Console.WriteLine("Old Kitchen: slozhi go na ogunq i gledai da ne se oparish");
        }

        public override void CookVegetarian()
        {
            Console.WriteLine("Old Kitchen: nqma vegetarianci");
        }
    }
}

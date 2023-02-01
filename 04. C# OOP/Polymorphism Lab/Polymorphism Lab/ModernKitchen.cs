using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class ModernKitchen : Kitchen
    {
        public override void CleanKitchen()
        {
            Console.WriteLine("Modern Kitchen: izhvurli vsichko i izmii");
        }

        public override void CookMeat()
        {
            Console.WriteLine("Modern Kitchen: sgotvi mesoto");
        }

        public override void CookVegetarian()
        {
            Console.WriteLine("Modern Kitchen: nqma vegetarianci");
        }

        public override void CookSalad()
        {
            Console.WriteLine("gurme salata (nqma q)");
        }

        public void RobotClean()
        {
            Console.WriteLine("Modern Kitchen : Robotite shte ni prevzemat");
        }
    }
}

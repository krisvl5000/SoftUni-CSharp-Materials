using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class RobotKitchen : ModernKitchen
    {
        public override void CookMeat()
        {
            Console.WriteLine("Robot Kitchen: nai-pravilno sgotvenoto meso");
        }

        public override void CookSalad()
        {
            Console.WriteLine("Robot Kitchen: gurme salata (nqma q)");
        }

        public override void RobotClean()
        {
            Console.WriteLine("Robot Kitchen : Robotite shte ni prevzemat");
        }
    }
}

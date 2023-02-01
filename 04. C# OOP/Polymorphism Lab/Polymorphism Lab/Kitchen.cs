using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public abstract class Kitchen
    {
        public abstract void CleanKitchen();

        public abstract void CookMeat();

        public virtual void CookSalad()
        {
            Console.WriteLine("In Kitchen: reja domati i krastavici i malko olio");
        }

        public abstract void CookVegetarian();
    }
}

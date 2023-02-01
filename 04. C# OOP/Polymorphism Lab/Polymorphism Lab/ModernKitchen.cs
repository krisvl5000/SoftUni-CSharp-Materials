﻿using System;
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
            Console.WriteLine("Modern Kitchen: slozhi go na ogunq i gledai da ne se oparish");
        }

        public override void CookVegetarian()
        {
            Console.WriteLine("Modern Kitchen: nqma vegetarianci");
        }

        public override void CookSalad()
        {
            Console.WriteLine("gurme salata (nqma q)");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKeyword
{
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle draw");
        }

        public int Raduis { get; set; }
    }
}

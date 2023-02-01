using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKeyword
{
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle draw");
        }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}

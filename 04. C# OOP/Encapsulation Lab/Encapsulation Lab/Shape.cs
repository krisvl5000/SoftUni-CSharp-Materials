using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Shape
    {
        private int drawCount = 0;
        private int maxDrawCount = 4000;
        private int x = 25;
        private int y = 10;

        private int size = 6;

        public virtual void Draw()
        {
            if (CanDrawShape())
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine($"Drawing shape! with size {6}");
            }
        }

        private bool CanDrawShape()
        {
            drawCount++;

            if (drawCount > maxDrawCount)
            {
                Console.WriteLine("Too many shapes");
                return false;
            }

            return true;
        }
    }
}

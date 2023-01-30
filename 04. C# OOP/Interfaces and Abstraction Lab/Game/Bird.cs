using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bird : IDrawable
    {
        public void Draw()
        {
            Console.WriteLine("Flapping");
        }
    }
}

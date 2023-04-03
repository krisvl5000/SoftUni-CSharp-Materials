using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Drawers.Contracts;
using Workshop.Shapes;

namespace Workshop.Drawers
{
    public class AdvancedShapeDrawer : IShapeDrawer
    {
        public void DrawCircle(Circle circle)
        {
            Console.WriteLine("  @@");
            Console.WriteLine("@    @");
            Console.WriteLine("@    @");
            Console.WriteLine("  @@");
        }

        public void DrawRectangle(Rectangle rectangle)
        {
            Console.WriteLine("@@@@");
            Console.WriteLine("@  @");
            Console.WriteLine("@  @");
            Console.WriteLine("@@@@");
        }
    }
}

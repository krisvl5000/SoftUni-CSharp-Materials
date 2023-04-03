using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Drawers.Contracts;
using Workshop.Renderers;
using Workshop.Shapes;

namespace Workshop.Drawers
{
    public class AdvancedShapeDrawer : BasicShapeDrawer
    {
        public AdvancedShapeDrawer(IRenderer renderer) : base(renderer)
        {
        }

        public override void DrawCircle(Circle circle)
        {
            Console.WriteLine("  @@");
            Console.WriteLine("@    @");
            Console.WriteLine("@    @");
            Console.WriteLine("  @@");
        }

        public override void DrawRectangle(Rectangle rectangle)
        {
            Console.WriteLine("@@@@");
            Console.WriteLine("@  @");
            Console.WriteLine("@  @");
            Console.WriteLine("@@@@");
        }
    }
}

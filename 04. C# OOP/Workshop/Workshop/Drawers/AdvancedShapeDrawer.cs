using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Common;
using Workshop.Drawers.Contracts;
using Workshop.Renderers;
using Workshop.Shapes;

namespace Workshop.Drawers
{
    public class AdvancedShapeDrawer : BasicShapeDrawer
    {
        private ILogger logger;
        public AdvancedShapeDrawer(IRenderer renderer, ILogger logger) : base(renderer)
        {
            this.logger = logger;
        }

        public override void DrawCircle(Circle circle)
        {
            logger.Log("Drawing Circle!");
            Console.WriteLine("  @@");
            Console.WriteLine("@    @");
            Console.WriteLine("@    @");
            Console.WriteLine("  @@");
        }

        public override void DrawRectangle(Rectangle rectangle)
        {
            logger.Log("Drawing Rectangle!");
            Console.WriteLine("@@@@");
            Console.WriteLine("@  @");
            Console.WriteLine("@  @");
            Console.WriteLine("@@@@");
        }
    }
}

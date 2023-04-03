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
    public class BasicShapeDrawer : IShapeDrawer
    {
        private readonly IRenderer renderer;
        public BasicShapeDrawer(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public virtual void DrawCircle(Circle circle)
        {
            renderer.WriteLine("  **");
            renderer.WriteLine("*    *");
            renderer.WriteLine("*    *");
            renderer.WriteLine("  **");
        }

        public virtual void DrawRectangle(Rectangle rectangle)
        {
            renderer.WriteLine("****");
            renderer.WriteLine("*  *");
            renderer.WriteLine("*  *");
            renderer.WriteLine("****");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Drawers.Contracts;
using Workshop.Shapes;

namespace Workshop
{
    public class Engine
    {
        private IShapeDrawer drawer;
        private List<Shape> shapes; 
        public Engine(IShapeDrawer drawer)
        {
            this.drawer = drawer;

            shapes = new List<Shape>
            {
                new Circle(),
                new Rectangle()
            };
        }

        public void Run()
        {
            foreach (var shape in shapes)
            {
                if (shape is Circle circle)
                {
                    drawer.DrawCircle(circle);
                }
                if (shape is Rectangle rectangle)
                {
                    drawer.DrawRectangle(rectangle);
                }
            }
        }
    }
}

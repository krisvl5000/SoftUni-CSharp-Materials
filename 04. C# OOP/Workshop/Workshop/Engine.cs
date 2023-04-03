using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Common;
using Workshop.Drawers.Contracts;
using Workshop.Shapes;

namespace Workshop
{
    public class Engine
    {
        private IShapeDrawer drawer;
        private List<Shape> shapes;
        private ILogger logger;
        public Engine(IShapeDrawer drawer, ILogger logger)
        {
            this.drawer = drawer;

            shapes = new List<Shape>
            {
                new Circle(),
                new Rectangle()
            };

            this.logger = logger;
        }

        public void Run()
        {
            foreach (var shape in shapes)
            {
                logger.Log($"Engine: Drawing {shape.GetType().Name}");
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

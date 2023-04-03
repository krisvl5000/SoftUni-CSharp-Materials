using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Shapes;

namespace Workshop.Drawers.Contracts
{
    public interface IShapeDrawer
    {
        public void DrawCircle(Circle circle);

        public void DrawRectangle(Rectangle rectangle);
    }
}

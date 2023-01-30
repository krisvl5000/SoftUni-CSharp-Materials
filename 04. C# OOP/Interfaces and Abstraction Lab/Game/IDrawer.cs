using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IDrawer
    {
        void Write(string message);

        void WriteLine(string message);

        void WriteAt(string message, int x, int y);
    }
}

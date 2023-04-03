using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Renderers
{
    public interface IRenderer
    {
        void Write(object obj);

        void WriteLine(object obj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public interface IWriter
    {
        void Write(object value);

        void WriteLine(object value);
    }
}

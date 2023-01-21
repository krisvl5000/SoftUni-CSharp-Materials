using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public class Box<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            return typeof(T).Name;
        }
    }
}

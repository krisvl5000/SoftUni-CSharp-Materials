using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public class Box<T>
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public override string ToString()
        {
            return $"{typeof(T)}: {Value}";
        }
    }
}

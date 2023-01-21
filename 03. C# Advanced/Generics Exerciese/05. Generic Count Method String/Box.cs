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

        public T Value { get; set; }

        public static int HowManyAreGreater<T>(List<Box<T>> list, T element)
        {
            Comparer<T> comparer = Comparer<T>.Default;

            int result = list
                .Where(x => comparer.Compare(x.Value, element) > 0)
                .ToList().Count;

            return result;
        }
    }
}

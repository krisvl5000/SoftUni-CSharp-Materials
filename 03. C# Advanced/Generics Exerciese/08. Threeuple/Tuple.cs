using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public class Tuple<T1, T2, T3>
    {
        public Tuple(T1 first, T2 second, T3 third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public T1 First { get; set; }

        public T2 Second { get; set; }

        public T3 Third { get; set; }

        public override string ToString()
        {
            return $"{First} -> {Second} -> {Third}";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public class Tuple<T1, T2>
    {
        public Tuple(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public T1 First { get; set; }

        public T2 Second { get; set; }

        public override string ToString()
        {
            return $"{First} -> {Second}";
        }
    }
}

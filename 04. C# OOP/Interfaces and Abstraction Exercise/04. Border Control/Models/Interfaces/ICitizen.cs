﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public interface ICitizen : IEntity
    {
        string Name { get; }

        int Age { get; }
    }
}

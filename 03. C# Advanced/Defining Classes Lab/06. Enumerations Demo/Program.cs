using System;
using System.Collections.Generic;

namespace Enumerations
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarState carState = CarState.ZaMorgata;

            Console.WriteLine(carState);

            Console.WriteLine((CarState)2);
        }
    }

    enum DayOfWeek
    {
        Monday = 55,
        Tuesday, // becomes 56
        Wednesday // becommes 57
    }
}
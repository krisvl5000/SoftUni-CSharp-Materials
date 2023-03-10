using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int BED_CAPACITY = 2;
        public DoubleBed() : base(BED_CAPACITY)
        {

        }
    }
}

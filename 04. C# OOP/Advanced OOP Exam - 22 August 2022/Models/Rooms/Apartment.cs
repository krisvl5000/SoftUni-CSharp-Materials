using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int BED_CAPACITY = 6;
        public Apartment() : base(BED_CAPACITY)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking
{
    internal class Hotel
    {
        public Hotel()
        {
            Reservations = new List<Reservation>();
        }

        public List<Reservation> Reservations { get; set; }

        public void AddReservation(DateTime startDate, DateTime endDate)
        {
            foreach (var item in Reservations)
            {
                bool overlap = item.Start < endDate && startDate < item.End;

                if (overlap)
                {
                    throw new ArgumentException("Hotel is already " +
                    $"booked for {startDate} and {endDate}!");
                }
            }
        }
    }
}

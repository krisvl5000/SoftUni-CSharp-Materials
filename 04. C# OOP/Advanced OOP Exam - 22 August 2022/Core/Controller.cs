using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Core.Contracts;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        public Controller()
        {
            
        }

        public string AddHotel(string hotelName, int category)
        {
            throw new NotImplementedException();
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            throw new NotImplementedException();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            throw new NotImplementedException();
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            throw new NotImplementedException();
        }

        public string HotelReport(string hotelName)
        {
            throw new NotImplementedException();
        }
    }
}

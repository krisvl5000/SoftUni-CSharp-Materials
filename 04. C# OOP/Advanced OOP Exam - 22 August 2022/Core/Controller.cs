using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            var hotel = new Hotel(hotelName, category);

            if (hotels.All().Any(x => x.FullName == hotelName))
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotels.AddNew(hotel);

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotels.All().All(x => x.FullName != hotelName))
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
            {
                return String.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            if (roomTypeName != "DoubleBed" && roomTypeName != "Apartment" && roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = null;

            if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }

            hotel.Rooms.AddNew(room);

            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.All().All(x => x.FullName != hotelName))
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (roomTypeName != "DoubleBed" && roomTypeName != "Apartment" && roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (hotel.Rooms.All().All(x => x.GetType().Name != roomTypeName))
            {
                return String.Format(OutputMessages.RoomTypeNotCreated);
            }

            var roomsToHaveTheirPricesChanged = hotel.Rooms.All().Where(x => x.GetType().Name == roomTypeName);

            if (roomsToHaveTheirPricesChanged.Any(x => x.PricePerNight != 0))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PriceAlreadySet));
            }

            foreach (var room in roomsToHaveTheirPricesChanged)
            {
                room.SetPrice(price);
            }

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var orderedHotels = hotels.All().OrderBy(x => x.FullName).ToList();

            if (orderedHotels.All(x => x.Category != category))
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            int totalGuests = adults + children;

            IRoom roomToReturn = totalGuests switch
            {
                <= 2 => new DoubleBed(),
                <= 4 => new Studio(),
                <= 6 => new Apartment(),
                _ => null
            };

            foreach (var hotel in orderedHotels)
            {
                var room = hotel.Rooms.All().Where(x => x.PricePerNight > 0).OrderBy(x => x.BedCapacity).FirstOrDefault(x => x.BedCapacity >= totalGuests);

                IBooking booking = new Booking(room, duration, adults, children, hotel.Bookings.All().Count + 1);
                hotel.Bookings.AddNew(booking);

                return String.Format(OutputMessages.BookingSuccessful, hotel.Bookings.All().Count, hotel.FullName);
            }

            return String.Format(OutputMessages.RoomNotAppropriate);
        }

        public string HotelReport(string hotelName)
        {
            var hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover: F2} $");

            if (hotel.Bookings.All().Any())
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.ToString());
                }
            }
            else
            {
                sb.AppendLine("none");
            }

            return sb.ToString().Trim();
        }
    }
}

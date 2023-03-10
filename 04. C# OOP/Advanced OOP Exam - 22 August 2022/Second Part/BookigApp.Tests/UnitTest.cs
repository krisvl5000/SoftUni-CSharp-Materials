using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        private Room room;
        private Booking booking;

        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("HotelName", 1);
            room = new Room(5, 10);
            booking = new Booking(10, room, 10);
        }

        [Test]
        public void IsHotelConstructorWorkingProperly()
        {
            Assert.That(hotel.FullName == "HotelName" && hotel.Category == 1);
        }

        [Test]
        public void IsRoomConstructorWorkingProperly()
        {
            Assert.That(room.BedCapacity == 5 && room.PricePerNight == 10);
        }

        [Test]
        public void IsBookingConstructorWorkingProperly()
        {
            Assert.That(booking.BookingNumber == 10 && booking.Room == room && booking.ResidenceDuration == 10);
        }


    }
}
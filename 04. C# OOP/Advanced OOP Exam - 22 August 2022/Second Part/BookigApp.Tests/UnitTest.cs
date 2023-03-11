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
            hotel = new Hotel("HotelName", 5);
            room = new Room(5, 10);
            booking = new Booking(10, room, 10);
        }

        [Test]
        public void Test_IsHotelConstructorWorkingProperly()
        {
            Assert.That(hotel.FullName == "HotelName" && hotel.Category == 5);
        }

        [Test]
        public void Test_HotelThrowingWhenTheNameIsEmpty()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                hotel = new Hotel("", 5);
            });
        }

        [Test]
        public void Test_HotelThrowingWhenTheCategoryIsInvalid()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                hotel = new Hotel("Name", 15);
            });
        }

        [Test]
        public void Test_IsRoomConstructorWorkingProperly()
        {
            Assert.That(room.BedCapacity == 5 && room.PricePerNight == 10);
        }

        [Test]
        public void Test_IsBookingConstructorWorkingProperly()
        {
            Assert.That(booking.BookingNumber == 10 && booking.Room == room && booking.ResidenceDuration == 10);
        }

        [Test]
        public void Test_IsHotelBookingsANewList()
        {
            Assert.That(hotel.Bookings.Count == 0);
        }

        [Test]
        public void Test_IsHotelRoomsANewList()
        {
            Assert.That(hotel.Rooms.Count == 0);
        }

        [Test]
        public void Test_IsHotelAddRoomWorkingProperly()
        {
            hotel.AddRoom(room);
            Assert.That(hotel.Rooms.Count == 1);
        }

        [Test]
        public void Test_IsAddBookingWorkingProperly()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(3, 1, 5, 100);
            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void Test_IsAddBookingThrowingWhenPassingInvalidValues()
        {
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(-1, 1, 5, 100);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(5, -3, 5, 100);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, 1, -5, 100);
            });
        }

        [Test]
        public void Test_IsTurnoverWorkingProperly()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(3, 1, 5, 100);
            Assert.AreEqual(50, hotel.Turnover);
        }
    }
}
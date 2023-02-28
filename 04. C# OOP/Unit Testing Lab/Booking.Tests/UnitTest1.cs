namespace Booking
{
    public class HotelTest
    {
        private Hotel hotel;
        private DateTime startDate;
        private DateTime endDate;

        [SetUp]
        public void SetUp()
        {
            hotel = new Hotel();
            startDate = new DateTime(2022, 11, 1);
            endDate = new DateTime(2022, 11, 5);
        }

        [Test]
        public void BookingWhenHotelAvailableShouldWork()
        {
            hotel.AddReservation(startDate, endDate);

            Assert.AreEqual(1, hotel.Reservations.Count, "Reservation" +
            "has not been added correctly.");

            Assert.AreEqual(startDate, hotel.Reservations[0].Start);

            Assert.AreEqual(endDate, hotel.Reservations[0].End);
        }

        [Test]
        public void MultipleBookingsWhenHotelAvailableShouldWork()
        {
            hotel.AddReservation(startDate, endDate);

            hotel.AddReservation(startDate.AddDays(10), endDate.AddDays(10));
            hotel.AddReservation(startDate.AddDays(25), endDate.AddDays(25));
            hotel.AddReservation(startDate.AddDays(56), endDate.AddDays(56));

            Assert.AreEqual(4, hotel.Reservations.Count, "Reservation" +
                                                         "has not been added correctly.");
        }

        [Test]
        public void TryingToAddOverlappingReservationsShouldThrow()
        {
            hotel.AddReservation(startDate, endDate);

            DateTime secondStart = new DateTime(2022, 11, 4);
            DateTime secondEnd = new DateTime(2022, 11, 7);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.AddReservation(secondStart, secondEnd);
            });
        }
    }
}
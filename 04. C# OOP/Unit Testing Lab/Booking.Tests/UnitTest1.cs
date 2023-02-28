namespace Booking
{
    public class HotelTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void BookingWhenHotelAvailableShouldWork()
        {
            Hotel hotel = new Hotel();

            DateTime startDate = new DateTime(2022, 11, 1);
            DateTime endDate = new DateTime(2022, 11, 5);

            hotel.AddReservation(startDate, endDate);

            Assert.AreEqual(1, hotel.Reservations.Count, "Reservation" +
            "has not been added correctly.");

            Assert.AreEqual(startDate, hotel.Reservations[0].Start);

            Assert.AreEqual(endDate, hotel.Reservations[0].End);
        }

        [Test]
        public void MultipleBookingsWhenHotelAvailableShouldWork()
        {
            Hotel hotel = new Hotel();

            DateTime startDate = new DateTime(2022, 11, 1);
            DateTime endDate = new DateTime(2022, 11, 5);

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
            Hotel hotel = new Hotel();

            DateTime startDate = new DateTime(2022, 11, 1);
            DateTime endDate = new DateTime(2022, 11, 5);
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
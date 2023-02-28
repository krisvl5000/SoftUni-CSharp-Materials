namespace Booking
{
    public class HotelTest
    { 
        [Test]
        public void BookingWhenHotelAvailableShouldWork()
        {
            Hotel hotel = new Hotel();

            DateTime startDate = new DateTime(2022, 11, 1);
            DateTime endDate = new DateTime(2022, 11, 5);

            hotel.AddReservation(startDate, endDate);

            Assert.AreEqual(1, hotel.Reservations.Count);
            Assert.AreEqual(startDate, hotel.Reservations[0].Start);
            Assert.AreEqual(endDate, hotel.Reservations[0].End);
        }
    }
}
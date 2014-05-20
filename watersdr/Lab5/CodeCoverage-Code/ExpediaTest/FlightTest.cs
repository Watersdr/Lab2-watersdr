using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//TODO Task 7 items go here

        [Test()]
        public void TestThatFlightlInitializes()
        {
            var start = new DateTime(1999, 1, 1);
            var end = new DateTime(1999, 2, 1);
            int miles = 100;

            var target = new Flight(start, end, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayTrip()
        {
            var start = new DateTime(1999, 1, 1);
            var end = new DateTime(1999, 1, 2);
            int miles = 100;
            var target = new Flight(start, end, miles);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayTrip()
        {
            var start = new DateTime(1999, 1, 1);
            var end = new DateTime(1999, 1, 3);
            int miles = 100;
            var target = new Flight(start, end, miles);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayTrip()
        {
            var start = new DateTime(1999, 1, 1);
            var end = new DateTime(1999, 1, 11);
            int miles = 100;
            var target = new Flight(start, end, miles);
            Assert.AreEqual(400, target.getBasePrice());
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadDistance()
        {
            var start = new DateTime(1999, 1, 1);
            var end = new DateTime(1999, 1, 2);
            int miles = -5;
            var target = new Flight(start, end, miles);
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            var start = new DateTime(1999, 1, 2);
            var end = new DateTime(1999, 1, 1);
            int miles = 100;
            var target = new Flight(start, end, miles);
        }
        [Test()]
        public void TestThatTwoFlightsAreEqual()
        {
            var start = new DateTime(1999, 1, 1);
            var end = new DateTime(1999, 1, 2);
            int miles = 100;
            var flight = new Flight(start, end, miles);

            var start1 = new DateTime(1999, 1, 1);
            var end1 = new DateTime(1999, 1, 2);
            int miles1 = 100;
            var flight1 = new Flight(start1, end1, miles1);

            Assert.True(flight.Equals(flight1));
        }
        [Test()]
        public void TestThatTwoFlightsNotEqual()
        {
            var start = new DateTime(1999, 1, 1);
            var end = new DateTime(1999, 1, 2);
            int miles = 100;
            var flight = new Flight(start, end, miles);

            //var start1 = new DateTime(1999, 1, 1);
            //var end1 = new DateTime(1999, 1, 4);
            //int miles1 = 200;
            var notFlight = new User("NotAFlight");

            Assert.False(flight.Equals(notFlight));
        }
	}
}

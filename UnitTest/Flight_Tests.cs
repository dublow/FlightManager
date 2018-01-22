using Business;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Flight_Tests
    {
        [TestMethod]
        public void ShouldBeAbleToCalculateDistanceBetweenDepartureCDGAndDestinationBRU()
        {
            Airport departureAirport = new Airport("CDG", 49.0097, 2.5479);
            Airport destinationAirport = new Airport("BRU", 50.9, 4.4836111111);

            AirportCalculator airportCalculator = new AirportCalculator(departureAirport, destinationAirport);

            double actual = airportCalculator.GetDistance();

            Assert.AreEqual(252, actual);
        }
    }
}

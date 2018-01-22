using Business;
using Domain;
using Domain.ValueType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Flight_Tests
    {
        [TestMethod]
        public void ShouldBeAbleToCalculateDistanceBetweenDepartureCDGAndDestinationBRU()
        {
            Location departureLocation = new Location(49.0097, 2.5479);
            Airport departureAirport = new Airport("CDG", departureLocation);

            Location destinationLocation = new Location(50.9, 4.4836111111);
            Airport destinationAirport = new Airport("BRU", destinationLocation);

            AirportCalculator airportCalculator = new AirportCalculator(departureAirport, destinationAirport);

            double actual = airportCalculator.GetDistance();

            Assert.AreEqual(252, actual);
        }

        [TestMethod]
        public void ShouldBeAbleToCalculateDistanceBetweenDepartureCDGAndDestinationSFO()
        {
            Location departureLocation = new Location(49.0097, 2.5479);
            Airport departureAirport = new Airport("CDG", departureLocation);

            Location destinationLocation = new Location(37.615223, -122.389977);
            Airport destinationAirport = new Airport("SFO", destinationLocation);

            AirportCalculator airportCalculator = new AirportCalculator(departureAirport, destinationAirport);

            double actual = airportCalculator.GetDistance();

            Assert.AreEqual(8957, actual);
        }
    }
}

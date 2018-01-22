using Business;
using Domain;
using Domain.Interfaces;
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

            IDistanceCalculator distanceCalculator = new DistanceMetricCalculator();
            IFuelConsumptionCalculator fuelConsumptionCalculator = new FuelConsumptionMetricCalculation();

            AirportCalculator airportCalculator = new AirportCalculator(
                departureAirport, destinationAirport, distanceCalculator, 
                fuelConsumptionCalculator);

            double actual = airportCalculator.GetDistance();

            Assert.AreEqual(251.50113319926041, actual);
        }

        [TestMethod]
        public void ShouldBeAbleToCalculateDistanceBetweenDepartureCDGAndDestinationSFO()
        {
            Location departureLocation = new Location(49.0097, 2.5479);
            Airport departureAirport = new Airport("CDG", departureLocation);

            Location destinationLocation = new Location(37.615223, -122.389977);
            Airport destinationAirport = new Airport("SFO", destinationLocation);

            IDistanceCalculator distanceCalculator = new DistanceMetricCalculator();
            IFuelConsumptionCalculator fuelConsumptionCalculator = new FuelConsumptionMetricCalculation();

            AirportCalculator airportCalculator = new AirportCalculator(
                departureAirport, destinationAirport, distanceCalculator,
                fuelConsumptionCalculator);

            double actual = airportCalculator.GetDistance();

            Assert.AreEqual(8956.68348155352, actual);
        }

        [TestMethod]
        public void ShouldBeAbleToCalculateFuelNeededBetweenDepartureCDGAndDestinationBRU()
        {
            Location departureLocation = new Location(49.0097, 2.5479);
            Airport departureAirport = new Airport("CDG", departureLocation);

            Location destinationLocation = new Location(50.9, 4.4836111111);
            Airport destinationAirport = new Airport("BRU", destinationLocation);

            Aircraft aircraft = new Aircraft("A380", 12000, 903, 8000);

            IDistanceCalculator distanceCalculator = new DistanceMetricCalculator();
            IFuelConsumptionCalculator fuelConsumptionCalculator = new FuelConsumptionMetricCalculation();

            AirportCalculator airportCalculator = new AirportCalculator(
                departureAirport, destinationAirport, distanceCalculator,
                fuelConsumptionCalculator);

            double actual = airportCalculator.GetFuelNeeded(aircraft);

            Assert.AreEqual(11342.207750156285, actual);
        }

        [TestMethod]
        public void ShouldBeAbleToCalculateFuelNeededBetweenDepartureCDGAndDestinationSFO()
        {
            Location departureLocation = new Location(49.0097, 2.5479);
            Airport departureAirport = new Airport("CDG", departureLocation);

            Location destinationLocation = new Location(37.615223, -122.389977);
            Airport destinationAirport = new Airport("SFO", destinationLocation);

            Aircraft aircraft = new Aircraft("A380", 12000, 903, 8000);

            IDistanceCalculator distanceCalculator = new DistanceMetricCalculator();
            IFuelConsumptionCalculator fuelConsumptionCalculator = new FuelConsumptionMetricCalculation();

            AirportCalculator airportCalculator = new AirportCalculator(
                departureAirport, destinationAirport, distanceCalculator,
                fuelConsumptionCalculator);

            double actual = airportCalculator.GetFuelNeeded(aircraft);

            Assert.AreEqual(127025.69410702353, actual);
        }
    }
}

using Domain.Interfaces;
using Domain.ValueType;
using System;

namespace Business
{
    public class DistanceMetricCalculator : IDistanceCalculator
    {
        public double GetDistance(Location departure, Location destination)
        {
            double circumference = 40000.0;
            double distance = 0.0;

            double departureLatitudeRad = DegreesToRadians(departure.Latitude);
            double departureLongitudeRad = DegreesToRadians(departure.Longitude);
            double destinationLatitudeRad = DegreesToRadians(destination.Latitude);
            double destinationLongitudeRad = DegreesToRadians(destination.Longitude);

            double logitudeDiff = Math.Abs(departureLongitudeRad - destinationLongitudeRad);

            if (logitudeDiff > Math.PI)
            {
                logitudeDiff = 2.0 * Math.PI - logitudeDiff;
            }

            double angleCalculation =
                Math.Acos(
                  Math.Sin(destinationLatitudeRad) * Math.Sin(departureLatitudeRad) +
                  Math.Cos(destinationLatitudeRad) * Math.Cos(departureLatitudeRad) * Math.Cos(logitudeDiff));

            distance = circumference * angleCalculation / (2.0 * Math.PI);

            return distance;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}

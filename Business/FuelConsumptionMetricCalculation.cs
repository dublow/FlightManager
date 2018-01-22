using Domain;
using Domain.Interfaces;
using System;

namespace Business
{
    public class FuelConsumptionMetricCalculation : IFuelConsumptionCalculator
    {
        public double GetNeeded(Aircraft aircraft, double totalDistance)
        {
            if (aircraft == null)
                throw new ArgumentNullException(nameof(aircraft));

            // Get time per distance
            var flightTime = totalDistance * 60 / aircraft.CruisingSpeed;

            // Get Fuel per time
            var fuelneeded = (flightTime * aircraft.ConsumptionPerHour / 60) 
                + aircraft.TakeOffEffort;

            return fuelneeded;
        }
    }
}

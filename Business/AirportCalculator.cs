using Domain;
using Domain.Interfaces;

namespace Business
{
    public class AirportCalculator
    {
        private readonly Airport _departure;
        private readonly Airport _destination;
        private readonly IDistanceCalculator _distanceCalculator;
        private readonly IFuelConsumptionCalculator _fuelConsumptionCalculator;

        public AirportCalculator(Airport departure, Airport destination, 
            IDistanceCalculator distanceCalculator,
            IFuelConsumptionCalculator fuelConsumptionCalculator)
        {
            _departure = departure;
            _destination = destination;
            _distanceCalculator = distanceCalculator;
            _fuelConsumptionCalculator = fuelConsumptionCalculator;
        }

        public double GetDistance()
        {
            return _distanceCalculator.GetDistance(_departure.Location, _destination.Location);
        }

        public double GetFuelNeeded(Aircraft aircraft)
        {
            return _fuelConsumptionCalculator.GetNeeded(aircraft, this.GetDistance());
        }
    }
}

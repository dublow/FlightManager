using Domain;
using Domain.Interfaces;

namespace Business
{
    public class AirportCalculator
    {
        private readonly Airport _departure;
        private readonly Airport _destination;
        private readonly IDistanceCalculator _distanceCalculator;

        public AirportCalculator(Airport departure, Airport destination, IDistanceCalculator distanceCalculator)
        {
            _departure = departure;
            _destination = destination;
            _distanceCalculator = distanceCalculator;
        }

        public double GetDistance()
        {
            return _distanceCalculator.GetDistance(_departure.Location, _destination.Location);
        }
    }
}

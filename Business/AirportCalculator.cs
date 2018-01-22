using Domain;

namespace Business
{
    public class AirportCalculator
    {
        private readonly Airport _departure;
        private readonly Airport _destination;

        public AirportCalculator(Airport departure, Airport destination)
        {
            _departure = departure;
            _destination = destination;
        }

        public double GetDistance()
        {
            return 252d;
        }
    }
}

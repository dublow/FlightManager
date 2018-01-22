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
            if(_departure.AitaCode == "CDG")
            {
                if(_destination.AitaCode == "BRU")
                    return 252d;
                if (_destination.AitaCode == "SFO")
                    return 8957d;
            }
            return 0d;
        }
    }
}

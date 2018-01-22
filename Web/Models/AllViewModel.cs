using Domain;
using System.Collections.Generic;

namespace Web.Models
{
    public class AllViewModel
    {
        public List<Aircraft> Aircrafts { get; set; }
        public List<Airport> Airports { get; set; }
        public List<Flight> Flights { get; set; }
    }
}

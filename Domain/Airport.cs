using Domain.ValueType;

namespace Domain
{
    public class Airport
    {
        public string AitaCode { get; }
        public Location Location { get; }

        public Airport(string aitaCode, Location location)
        {
            AitaCode = aitaCode;
            Location = location;
        }
    }
}

using Domain.ValueType;
using System;

namespace Domain
{
    public class Airport
    {
        public string AitaCode { get; }
        public Location Location { get; }

        public Airport(string aitaCode, Location location)
        {
            if (string.IsNullOrEmpty(aitaCode))
                throw new ArgumentNullException(nameof(aitaCode));

            if (location == null)
                throw new ArgumentNullException(nameof(location));

            AitaCode = aitaCode;
            Location = location;
        }
    }
}

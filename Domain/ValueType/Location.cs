using System;
using System.Collections.Generic;

namespace Domain.ValueType
{
    public class Location : IEquatable<Location>
    {
        public Double Latitude { get; }
        public Double Longitude { get; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Location);
        }

        public bool Equals(Location other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return (Latitude == other.Latitude) && (Longitude == other.Longitude);
        }

        public override int GetHashCode()
        {
            var hashCode = -1416534245;
            hashCode = hashCode * -1521134295 + Latitude.GetHashCode();
            hashCode = hashCode * -1521134295 + Longitude.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Location location1, Location location2)
        {
            return EqualityComparer<Location>.Default.Equals(location1, location2);
        }

        public static bool operator !=(Location location1, Location location2)
        {
            return !(location1 == location2);
        }
    }
}

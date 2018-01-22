using Domain.ValueType;

namespace Domain.Interfaces
{
    public interface IDistanceCalculator
    {
        double GetDistance(Location departure, Location destination);
    }
}

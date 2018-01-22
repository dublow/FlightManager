namespace Domain.Interfaces
{
    public interface IFuelConsumptionCalculator
    {
        double GetNeeded(Aircraft aircraft, double totalDistance);
    }
}

namespace Domain.Repositories
{
    public interface IFlightRepository
    {
        void Add(Flight flight);
        bool Exist(string aitaDeparture, string aitaDestination, string aircraftModel);
    }
}

namespace Domain.Repositories
{
    public interface IFlightRepository
    {
        void Add(Flight flight);
        void Update(Flight flight);
        bool Exist(string aitaDeparture, string aitaDestination, string aircraftModel);
    }
}

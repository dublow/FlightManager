namespace Domain.Repositories
{
    public interface IAirportRepository
    {
        void Add(Airport airport);
        bool Exist(string aitaCode);
    }
}

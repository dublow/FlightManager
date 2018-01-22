using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IAirportRepository
    {
        void Add(Airport airport);
        void Update(Airport airport);
        bool Exist(string aitaCode);
        Airport Get(string aitaCode);
        List<Airport> GetAll();
    }
}

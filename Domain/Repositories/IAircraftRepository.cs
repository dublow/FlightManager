using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IAircraftRepository
    {
        void Add(Aircraft aircraft);
        void Update(Aircraft aircraft);
        bool Exist(string model);
        Aircraft Get(string model);
        List<Aircraft> GetAll();
    }
}

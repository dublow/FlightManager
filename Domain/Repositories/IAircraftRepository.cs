namespace Domain.Repositories
{
    public interface IAircraftRepository
    {
        void Add(Aircraft aircraft);
        void Update(Aircraft aircraft);
        bool Exist(string model);
    }
}

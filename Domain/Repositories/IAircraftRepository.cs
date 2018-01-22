namespace Domain.Repositories
{
    public interface IAircraftRepository
    {
        void Add(Aircraft aircraft);
        bool Exist(string model);
    }
}

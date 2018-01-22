using System.Data;

namespace Infrastructure
{
    public interface IProvider
    {
        IDbConnection Create();
    }
}

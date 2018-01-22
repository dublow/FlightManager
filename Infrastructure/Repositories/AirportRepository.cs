using Domain;
using Domain.Repositories;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Infrastructure.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly IProvider _provider;

        public AirportRepository(IProvider provider)
        {
            _provider = provider;
        }

        public void Add(Airport airport)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "INSERT INTO Airport (AitaCode, Latitude, Longitude) " +
                    "VALUES (@aitaCode, @latitude, @longitude)";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@aitaCode", airport.AitaCode));
                    command.Parameters.Add(new SqliteParameter("@latitude", airport.Location.Latitude));
                    command.Parameters.Add(new SqliteParameter("@longitude", airport.Location.Longitude));

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}

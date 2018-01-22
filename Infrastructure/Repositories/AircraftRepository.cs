using Domain;
using Domain.Repositories;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Infrastructure.Repositories
{
    public class AircraftRepository : IAircraftRepository
    {
        private readonly IProvider _provider;

        public AircraftRepository(IProvider provider)
        {
            _provider = provider;
        }

        public void Add(Aircraft aircraft)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();
                
                var query =
                    "INSERT INTO Aircraft (Model, ConsumptionPerHour, CruisingSpeed, TakeOffEffort) " +
                    "VALUES (@model, @consumptionPerHour, @cruisingSpeed, @takeOffEffort)";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@model", aircraft.Model));
                    command.Parameters.Add(new SqliteParameter("@consumptionPerHour", aircraft.ConsumptionPerHour));
                    command.Parameters.Add(new SqliteParameter("@cruisingSpeed", aircraft.CruisingSpeed));
                    command.Parameters.Add(new SqliteParameter("@takeOffEffort", aircraft.TakeOffEffort));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Aircraft aircraft)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "UPDATE Aircraft " +
                    "SET ConsumptionPerHour = @consumptionPerHour, " +
                    "CruisingSpeed = @cruisingSpeed, " +
                    "TakeOffEffort = @takeOffEffort " +
                    "WHERE Model = @model";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@model", aircraft.Model));
                    command.Parameters.Add(new SqliteParameter("@consumptionPerHour", aircraft.ConsumptionPerHour));
                    command.Parameters.Add(new SqliteParameter("@cruisingSpeed", aircraft.CruisingSpeed));
                    command.Parameters.Add(new SqliteParameter("@takeOffEffort", aircraft.TakeOffEffort));

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Exist(string model)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "SELECT Model FROM Aircraft where Model = @model";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@model", model));

                    var reader = command.ExecuteReader();

                    return reader.Read();
                }
            }
        }
    }
}

using Domain;
using Domain.Repositories;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IProvider _provider;

        public FlightRepository(IProvider provider)
        {
            _provider = provider;
        }

        public void Add(Flight flight)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "INSERT INTO Flight (AitaCodeDeparture, AitaCodeDestination, AircraftModel, Distance, FuelNeeded) " +
                    "VALUES (@aitaCodeDeparture, @aitaCodeDestination, @aircraftModel, @distance, @fuelNeeded)";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@aitaCodeDeparture", flight.AitaCodeDeparture));
                    command.Parameters.Add(new SqliteParameter("@aitaCodeDestination", flight.AitaCodeDestination));
                    command.Parameters.Add(new SqliteParameter("@aircraftModel", flight.AircraftModel));
                    command.Parameters.Add(new SqliteParameter("@distance", flight.Distance));
                    command.Parameters.Add(new SqliteParameter("@fuelNeeded", flight.FuelNeeded));

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public void Update(Flight flight)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "UPDATE Flight " +
                    "SET Distance = @distance, " +
                    "FuelNeeded = @fuelNeeded " +
                    "WHERE AitaCodeDeparture = @aitaCodeDeparture " +
                    "AND AitaCodeDestination = @aitaCodeDestination " +
                    "AND AircraftModel = @aircraftModel";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@aitaCodeDeparture", flight.AitaCodeDeparture));
                    command.Parameters.Add(new SqliteParameter("@aitaCodeDestination", flight.AitaCodeDestination));
                    command.Parameters.Add(new SqliteParameter("@aircraftModel", flight.AircraftModel));
                    command.Parameters.Add(new SqliteParameter("@distance", flight.Distance));
                    command.Parameters.Add(new SqliteParameter("@fuelNeeded", flight.FuelNeeded));

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public bool Exist(string aitaDeparture, string aitaDestination, string aircraftModel)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "SELECT aitaCodeDeparture FROM Flight " +
                    "WHERE AitaCodeDeparture = @aitaDeparture " +
                    "AND AitaCodeDestination = @aitaDestination " +
                    "AND AircraftModel = @aircraftModel";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@aitaCodeDeparture", aitaDeparture));
                    command.Parameters.Add(new SqliteParameter("@aitaCodeDestination", aitaDestination));
                    command.Parameters.Add(new SqliteParameter("@aircraftModel", aircraftModel));

                    var reader = command.ExecuteReader();

                    return reader.Read();
                }
            }
        }

        public Flight Get(string aitaDeparture, string aitaDestination, string aircraftModel)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "SELECT * FROM Flight " +
                    "WHERE AitaCodeDeparture = @aitaCodeDeparture " +
                    "AND AitaCodeDestination = @aitaCodeDestination " +
                    "AND AircraftModel = @aircraftModel";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@aitaCodeDeparture", aitaDeparture));
                    command.Parameters.Add(new SqliteParameter("@aitaCodeDestination", aitaDestination));
                    command.Parameters.Add(new SqliteParameter("@aircraftModel", aircraftModel));

                    var reader = command.ExecuteReader();

                    var results = new List<Flight>();
                    while (reader.Read())
                    {
                        results.Add(
                            new Flight(
                                (string)reader["AitaCodeDeparture"], 
                                (string)reader["AitaCodeDestination"],
                                (string)reader["AircraftModel"],
                                double.Parse(reader["Distance"].ToString()),
                                double.Parse(reader["FuelNeeded"].ToString())
                                ));
                    }

                    return results.SingleOrDefault();
                }
            }
        }

        public List<Flight> GetAll()
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "SELECT * FROM Flight";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();

                    var results = new List<Flight>();
                    while (reader.Read())
                    {
                        results.Add(
                            new Flight(
                                (string)reader["AitaCodeDeparture"],
                                (string)reader["AitaCodeDestination"],
                                (string)reader["AircraftModel"],
                                double.Parse(reader["Distance"].ToString()),
                                double.Parse(reader["FuelNeeded"].ToString())
                                ));
                    }

                    return results;
                }
            }
        }
    }
}

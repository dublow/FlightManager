﻿using Domain;
using Domain.Repositories;
using Microsoft.Data.Sqlite;
using System.Data;

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

        public bool Exist(string aitaDeparture, string aitaDestination, string aircraftModel)
        {
            using (var connection = _provider.Create())
            {
                connection.Open();

                var query =
                    "SELECT aitaDeparture FROM Airport " +
                    "WHERE AitaDeparture = @aitaDeparture " +
                    "AND AitaDestination = @aitaDestination " +
                    "AND AircraftModel = @aircraftModel";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqliteParameter("@aitaDeparture", aitaDeparture));
                    command.Parameters.Add(new SqliteParameter("@aitaDestination", aitaDestination));
                    command.Parameters.Add(new SqliteParameter("@aircraftModel", aircraftModel));

                    var reader = command.ExecuteReader();

                    return reader.Read();
                }
            }
        }
    }
}

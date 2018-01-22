using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace Infrastructure
{
    public class SqlLiteProvider : IProvider
    {
        private readonly string _connectionString;

        public SqlLiteProvider(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;
        }

        public IDbConnection Create()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}

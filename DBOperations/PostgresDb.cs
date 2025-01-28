using Npgsql;
using System.Data;

namespace DbOperations;

class PostgresDb : Database
{
    public PostgresDb(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public override void ExecuteQuery(string query)
    {
        using IDbConnection connection = new NpgsqlConnection(ConnectionString);
        if (connection is null)
        {
            Console.WriteLine("Error in connecting to database");

            return;
        }

        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = query;

        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var Name = reader.GetString(0);
            var Number = reader.GetInt32(1);
            Console.WriteLine($"{Name}\t{Number}");
        }

        connection.Close();
    }

}
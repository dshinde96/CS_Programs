using System.Data;
using System.Data.SQLite;

namespace DbOperations;

class SqlLiteDb : Database
{

    public SqlLiteDb(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public override void ExecuteQuery(string query)
    {
        IDbConnection connection = new SQLiteConnection(ConnectionString);
        if (connection == null)
        {
            Console.WriteLine("Error in connecting to database");
            return;
        }
        connection.Open();
        IDbCommand command = connection.CreateCommand();
        command.CommandText = query;

        using IDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var Name = reader.GetString(0);
            var Number = reader.GetInt32(1);
            Console.WriteLine($"{Name}\t{Number}");
        }
        connection.Close();
    }
}

namespace DbOperations;

class Program
{

    public static void Main(string[] args)
    {

        Console.WriteLine("\n\nRetrive Data from PG: 1\nInsert data into pg: 2\nRetrive data from SQLite: 3\nInsert Data in SQLite: 4\n");
        int choice = Convert.ToInt32(Console.ReadLine());
        Database db;
        string connectionString;

        while (choice != 0)
        {
            switch (choice)
            {
                case 1:
                    connectionString = ConfigurationHelper.GetConnectionString("PostgresConnection");
                    db = new PostgresDb(connectionString);
                    db.ExecuteQuery("SELECT * FROM contact;");
                    break;

                case 3:
                    connectionString = ConfigurationHelper.GetConnectionString("SqlConnection");
                    db = new SqlLiteDb(connectionString);
                    db.ExecuteQuery("SELECT * FROM contact;");
                    break;
            }

            Console.WriteLine("\nRetrive Data from PG: 1\nRetrive data from SQLite: 2");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

        }
    }


}
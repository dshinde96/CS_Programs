namespace DbOperations;

abstract class Database
{
    protected string? ConnectionString;

    public abstract void ExecuteQuery(string query);
}
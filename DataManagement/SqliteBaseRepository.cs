using Microsoft.Data.Sqlite;

namespace DataManagement;

public abstract class SqliteBaseRepository(string dbConnectionString)
{
    protected readonly string DbConnectionString = dbConnectionString;

    protected SqliteConnection GetConnection()
    {
        return new SqliteConnection(DbConnectionString);
    }
}
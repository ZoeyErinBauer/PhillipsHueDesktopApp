using System.Reflection;
using Microsoft.Data.Sqlite;

namespace DataManagement;

public interface IDbContext
{
    IQueryable<T> Query<T>() where T : new();
    void ExecuteNonQuery(string query);
}

public class DbContext : IDbContext
{
    private readonly SqliteConnection _connection;

    public DbContext(string connectionString)
    {
        _connection = new SqliteConnection(connectionString);
        _connection.Open();
    }

    public IQueryable<T> Query<T>() where T : new()
    {
        var tableName = typeof(T).Name;
        using var command = new SqliteCommand($"SELECT * FROM {tableName}", _connection);
        using var reader = command.ExecuteReader();
        var result = new List<T>();
        while (reader.Read())
        {
            var item = new T();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                typeof(T).GetProperty(reader.GetName(i))?.SetValue(item, reader.GetValue(i));
            }

            result.Add(item);
        }

        return result.AsQueryable();
    }


    public void ExecuteNonQuery(string query)
    {
        using var command = new SqliteCommand(query, _connection);
        command.ExecuteNonQuery();
    }

    private string GenerateInsertQuery<T>(T item)
    {
        Type itemType = item.GetType();
        PropertyInfo[] properties = itemType.GetProperties();
        var tableName = itemType.Name;

        string columns = string.Join(", ", properties.Select(p => p.Name));
        string values = string.Join(", ", properties.Select(p => $"'{p.GetValue(item)}'"));

        return $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
    }
}
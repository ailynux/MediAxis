using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

public class DatabaseContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(_connectionString));
    }

    public IDbConnection CreateConnection()
        => new SqliteConnection(_connectionString);
}
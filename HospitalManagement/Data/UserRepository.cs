using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var query = "SELECT * FROM Users";

        using (var connection = _context.CreateConnection())
        {
            var users = await connection.QueryAsync<User>(query);
            return users;
        }
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var query = "SELECT * FROM Users WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
            return user;
        }
    }

    public async Task CreateUserAsync(User user)
    {
        var query = "INSERT INTO Users (Name, Email, Role, PasswordHash) VALUES (@Name, @Email, @Role, @PasswordHash)";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, user);
        }
    }

    public async Task UpdateUserAsync(User user)
    {
        var query = "UPDATE Users SET Name = @Name, Email = @Email, Role = @Role, PasswordHash = @PasswordHash WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, user);
        }
    }

    public async Task DeleteUserAsync(int id)
    {
        var query = "DELETE FROM Users WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
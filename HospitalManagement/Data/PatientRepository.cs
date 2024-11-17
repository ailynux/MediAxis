using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PatientRepository
{
    private readonly DatabaseContext _context;

    public PatientRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
    {
        var query = "SELECT * FROM Patients";

        using (var connection = _context.CreateConnection())
        {
            var patients = await connection.QueryAsync<Patient>(query);
            return patients;
        }
    }

    public async Task<Patient?> GetPatientByIdAsync(int id)
    {
        var query = "SELECT * FROM Patients WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            var patient = await connection.QuerySingleOrDefaultAsync<Patient>(query, new { Id = id });
            return patient;
        }
    }

    public async Task CreatePatientAsync(Patient patient)
    {
        var query = "INSERT INTO Patients (Name, Email, DateOfBirth, Gender, Address, PhoneNumber) VALUES (@Name, @Email, @DateOfBirth, @Gender, @Address, @PhoneNumber)";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, patient);
        }
    }

    public async Task UpdatePatientAsync(Patient patient)
    {
        var query = "UPDATE Patients SET Name = @Name, Email = @Email, DateOfBirth = @DateOfBirth, Gender = @Gender, Address = @Address, PhoneNumber = @PhoneNumber WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, patient);
        }
    }

    public async Task DeletePatientAsync(int id)
    {
        var query = "DELETE FROM Patients WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class HealthRecordRepository
{
    private readonly DatabaseContext _context;

    public HealthRecordRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HealthRecord>> GetAllHealthRecordsAsync()
    {
        var query = "SELECT * FROM HealthRecords";

        using (var connection = _context.CreateConnection())
        {
            var healthRecords = await connection.QueryAsync<HealthRecord>(query);
            return healthRecords;
        }
    }

    public async Task<HealthRecord?> GetHealthRecordByIdAsync(int id)
    {
        var query = "SELECT * FROM HealthRecords WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            var healthRecord = await connection.QuerySingleOrDefaultAsync<HealthRecord>(query, new { Id = id });
            return healthRecord;
        }
    }

    public async Task CreateHealthRecordAsync(HealthRecord healthRecord)
    {
        var query = "INSERT INTO HealthRecords (PatientId, Diagnosis, Treatment, Date) VALUES (@PatientId, @Diagnosis, @Treatment, @Date)";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, healthRecord);
        }
    }

    public async Task UpdateHealthRecordAsync(HealthRecord healthRecord)
    {
        var query = "UPDATE HealthRecords SET PatientId = @PatientId, Diagnosis = @Diagnosis, Treatment = @Treatment, Date = @Date WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, healthRecord);
        }
    }

    public async Task DeleteHealthRecordAsync(int id)
    {
        var query = "DELETE FROM HealthRecords WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
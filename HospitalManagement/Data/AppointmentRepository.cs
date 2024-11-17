using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AppointmentRepository
{
    private readonly DatabaseContext _context;

    public AppointmentRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
    {
        var query = "SELECT * FROM Appointments";

        using (var connection = _context.CreateConnection())
        {
            var appointments = await connection.QueryAsync<Appointment>(query);
            return appointments;
        }
    }

    public async Task<Appointment?> GetAppointmentByIdAsync(int id)
    {
        var query = "SELECT * FROM Appointments WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            var appointment = await connection.QuerySingleOrDefaultAsync<Appointment>(query, new { Id = id });
            return appointment;
        }
    }

    public async Task CreateAppointmentAsync(Appointment appointment)
    {
        var query = "INSERT INTO Appointments (DoctorId, PatientId, AppointmentDate, Status) VALUES (@DoctorId, @PatientId, @AppointmentDate, @Status)";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, appointment);
        }
    }

    public async Task UpdateAppointmentAsync(Appointment appointment)
    {
        var query = "UPDATE Appointments SET DoctorId = @DoctorId, PatientId = @PatientId, AppointmentDate = @AppointmentDate, Status = @Status WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, appointment);
        }
    }

    public async Task DeleteAppointmentAsync(int id)
    {
        var query = "DELETE FROM Appointments WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
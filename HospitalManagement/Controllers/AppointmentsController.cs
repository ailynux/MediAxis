using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly AppointmentRepository _appointmentRepository;

    public AppointmentsController(AppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Appointment>> GetAppointments()
    {
        return await _appointmentRepository.GetAllAppointmentsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> GetAppointment(int id)
    {
        var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);

        if (appointment == null)
        {
            return NotFound();
        }

        return appointment;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAppointment(Appointment appointment)
    {
        await _appointmentRepository.CreateAppointmentAsync(appointment);
        return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(int id, Appointment appointment)
    {
        if (id != appointment.Id)
        {
            return BadRequest();
        }

        await _appointmentRepository.UpdateAppointmentAsync(appointment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        await _appointmentRepository.DeleteAppointmentAsync(id);
        return NoContent();
    }
}
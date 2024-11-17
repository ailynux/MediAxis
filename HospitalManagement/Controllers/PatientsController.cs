using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly PatientRepository _patientRepository;

    public PatientsController(PatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Patient>> GetPatients()
    {
        return await _patientRepository.GetAllPatientsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
        var patient = await _patientRepository.GetPatientByIdAsync(id);

        if (patient == null)
        {
            return NotFound();
        }

        return patient;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePatient(Patient patient)
    {
        await _patientRepository.CreatePatientAsync(patient);
        return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, Patient patient)
    {
        if (id != patient.Id)
        {
            return BadRequest();
        }

        await _patientRepository.UpdatePatientAsync(patient);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        await _patientRepository.DeletePatientAsync(id);
        return NoContent();
    }
}
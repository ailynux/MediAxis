using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class HealthRecordsController : ControllerBase
{
    private readonly HealthRecordRepository _healthRecordRepository;

    public HealthRecordsController(HealthRecordRepository healthRecordRepository)
    {
        _healthRecordRepository = healthRecordRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<HealthRecord>> GetHealthRecords()
    {
        return await _healthRecordRepository.GetAllHealthRecordsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HealthRecord>> GetHealthRecord(int id)
    {
        var healthRecord = await _healthRecordRepository.GetHealthRecordByIdAsync(id);

        if (healthRecord == null)
        {
            return NotFound();
        }

        return healthRecord;
    }

    [HttpPost]
    public async Task<ActionResult> CreateHealthRecord(HealthRecord healthRecord)
    {
        await _healthRecordRepository.CreateHealthRecordAsync(healthRecord);
        return CreatedAtAction(nameof(GetHealthRecord), new { id = healthRecord.Id }, healthRecord);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHealthRecord(int id, HealthRecord healthRecord)
    {
        if (id != healthRecord.Id)
        {
            return BadRequest();
        }

        await _healthRecordRepository.UpdateHealthRecordAsync(healthRecord);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHealthRecord(int id)
    {
        await _healthRecordRepository.DeleteHealthRecordAsync(id);
        return NoContent();
    }
}
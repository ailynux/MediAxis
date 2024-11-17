using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
    public async Task<ActionResult<IEnumerable<HealthRecord>>> GetHealthRecords()
    {
        try
        {
            var healthRecords = await _healthRecordRepository.GetAllHealthRecordsAsync();
            return Ok(healthRecords);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework)
            Console.WriteLine($"Error in GetHealthRecords: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HealthRecord>> GetHealthRecord(int id)
    {
        try
        {
            var healthRecord = await _healthRecordRepository.GetHealthRecordByIdAsync(id);
            if (healthRecord == null)
            {
                return NotFound();
            }
            return Ok(healthRecord);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework)
            Console.WriteLine($"Error in GetHealthRecord: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateHealthRecord(HealthRecord healthRecord)
    {
        try
        {
            await _healthRecordRepository.CreateHealthRecordAsync(healthRecord);
            return CreatedAtAction(nameof(GetHealthRecord), new { id = healthRecord.Id }, healthRecord);
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework)
            Console.WriteLine($"Error in CreateHealthRecord: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHealthRecord(int id, HealthRecord healthRecord)
    {
        try
        {
            if (id != healthRecord.Id)
            {
                return BadRequest();
            }

            await _healthRecordRepository.UpdateHealthRecordAsync(healthRecord);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework)
            Console.WriteLine($"Error in UpdateHealthRecord: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHealthRecord(int id)
    {
        try
        {
            await _healthRecordRepository.DeleteHealthRecordAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Log the exception (you can use a logging framework)
            Console.WriteLine($"Error in DeleteHealthRecord: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}
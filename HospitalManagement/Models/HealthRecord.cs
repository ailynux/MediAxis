public class HealthRecord
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string Treatment { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
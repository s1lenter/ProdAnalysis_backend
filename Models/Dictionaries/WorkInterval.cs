namespace ProductionAnalysisBackend.Models;

public class WorkInterval
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int DurationMinutes { get; set; }
}
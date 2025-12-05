namespace ProductionAnalysisBackend.Models;

public class Equipment
{
    public int Id { get; set; }
    public int DepartmentId  { get; set; }
    public string Name { get; set; } = null!;
    public int PowerPerHour { get; set; }
}
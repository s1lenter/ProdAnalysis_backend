namespace ProductionAnalysisBackend.Models;

public class Shift
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Status { get; set; }
    public int Duration { get; set; }
    
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    
    public int OperatorId { get; set; }
    public User Operator { get; set; }
    
    public int CreatorId { get; set; }
}
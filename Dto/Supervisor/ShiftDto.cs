namespace ProductionAnalysisBackend.Dto.Supervisor;

public class ShiftDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string DepartmentName { get; set; }
    public string OperatorName { get; set; }
    public int DepartmentId { get; set; }
    public int OperatorId { get; set; }
}
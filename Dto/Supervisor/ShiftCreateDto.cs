namespace ProductionAnalysisBackend.Dto.Supervisor;

public class ShiftCreateDto
{
    public DateTime StartTime { get; set; }
    public int DepartmentId { get; set; }
    public int OperatorId { get; set; }
}
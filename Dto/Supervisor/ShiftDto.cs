namespace ProductionAnalysisBackend.Dto.Supervisor;

public class ShiftDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public int DepartmentId { get; set; }
    public int OperatorId { get; set; }
}
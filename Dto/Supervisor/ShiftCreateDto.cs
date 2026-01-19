namespace ProductionAnalysisBackend.Dto.Supervisor;

public class ShiftCreateDto
{
    public string ShiftType { get; set; }
    public int DepartmentId { get; set; }
    public int OperatorId { get; set; }
}
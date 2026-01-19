namespace ProductionAnalysisBackend.Dto.Tables;

public class PowerPerHourTableCreateDto
{
    public int ProductId { get; set; }
    public int DepartmentId { get; set; }
    public int OperatorId { get; set; }
    public int ShiftId { get; set; }
    public int PowerPerHour { get; set; }
    public int DailyTarget { get; set; }
    public string ScenarioName { get; set; }
}
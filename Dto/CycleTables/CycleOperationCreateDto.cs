namespace ProductionAnalysisBackend.Dto.CycleTables;

public class CycleOperationCreateDto
{
    public string Name { get; set; }
    public int DurationMinutes { get; set; }
    public int PlanQty { get; set; }
}
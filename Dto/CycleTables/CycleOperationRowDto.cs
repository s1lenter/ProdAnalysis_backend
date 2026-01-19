namespace ProductionAnalysisBackend.Dto.CycleTables;

public class CycleOperationRowDto
{
    public int OperationId { get; set; }

    public int Order { get; set; }
    public string Name { get; set; }

    public int DurationMinutes { get; set; }
    public int PlanQty { get; set; }

    // ФАКТ (редактируемое)
    public int? FactDurationMinutes { get; set; }
    public string? Comment { get; set; }
}

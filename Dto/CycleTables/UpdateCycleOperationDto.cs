namespace ProductionAnalysisBackend.Dto.CycleTables;

public class UpdateCycleOperationDto
{
    public int OperationId { get; set; }

    public int FactDurationMinutes { get; set; }
    public string? Comment { get; set; }
}
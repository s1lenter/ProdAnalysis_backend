namespace ProductionAnalysisBackend.Dto.Tables;

public class UpdateRowDto
{
    public int RowId { get; set; }

    public int FactQTY { get; set; }
    public int DowntimeMinutes { get; set; }

    public int? ReasonGroupId { get; set; }
    // public int? ReasonId { get; set; }
    public int? ResponsibleUserId { get; set; }

    public string? Comment { get; set; }
    public string? TakenMeasures { get; set; }
}
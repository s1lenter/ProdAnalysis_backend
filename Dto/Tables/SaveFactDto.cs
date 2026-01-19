namespace ProductionAnalysisBackend.Dto.Tables;

public class SaveFactRowDto
{
    public int RowId { get; set; }

    public int FactQTY { get; set; }
    public int FactCumulative { get; set; }
    public int DowntimeMinutes { get; set; }

    // данные по простою
    public int? ReasonGroupId { get; set; }
    public int? ReasonId { get; set; }
    public int? ResponsibleUserId { get; set; }

    public string? Comment { get; set; }
    public string? TakenMeasures { get; set; }
}
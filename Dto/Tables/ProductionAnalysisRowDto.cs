namespace ProductionAnalysisBackend.Dto.Tables;

public class ProductionAnalysisRowDto
{
    public int RowId { get; set; }

    public string WorkInterval { get; set; }

    public int PlanQTY { get; set; }
    public int PlanCumulative { get; set; }

    public int FactQTY { get; set; }
    public int FactCumulative { get; set; }

    public int Deviation { get; set; }
    public int DeviationCumulative { get; set; }

    public int DowntimeMinutes { get; set; }

    public int? ResponsibleUserId { get; set; }
    public string? ResponsibleUserName { get; set; }

    public int? ReasonGroupId { get; set; }
    public string? ReasonGroupName { get; set; }

    public int? ReasonId { get; set; }
    public string? ReasonName { get; set; }

    public string? Comment { get; set; }
    public string? TakenMeasures { get; set; }
}
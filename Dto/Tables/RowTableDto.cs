namespace ProductionAnalysisBackend.Dto.Tables;

public class RowTableDto
{
    public int RowId { get; set; }

    public int PlanQTY { get; set; }
    public int PlanCumulative { get; set; }

    public int FactQTY { get; set; }
    // public int FactCumulative { get; set; }

    public int DowntimeMinutes { get; set; }

    public int? DeviationValue { get; set; }

    public int? ReasonGroupId { get; set; }
    public string? ReasonGroupName { get; set; }

    public int? ReasonId { get; set; }
    public string? ReasonDescription { get; set; }

    public int? ResponsibleUserId { get; set; }
    public string? ResponsibleUserName { get; set; }

    public string? Comment { get; set; }
    public string? TakenMeasures { get; set; }
}

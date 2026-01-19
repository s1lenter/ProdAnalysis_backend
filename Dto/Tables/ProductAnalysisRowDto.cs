namespace ProductionAnalysisBackend.Dto.Tables;

public class ProductAnalysisRowDto
{
    public int RowId { get; set; }
    public string WorkInterval { get; set; }

    public int PlanQTY { get; set; }
    public int PlanCumulative { get; set; }

    public int FactQTY { get; set; }
    // public int FactCumulative { get; set; }

    public int Deviation { get; set; }

    public int DowntimeMinutes { get; set; }

    public string? ReasonGroup { get; set; }
    public string? Reason { get; set; }
    public string? Responsible { get; set; }

    public string? Comment { get; set; }
    public string? TakenMeasures { get; set; }
}
namespace ProductionAnalysisBackend.Dto.Excel;


public class ProductionAnalysisExcelRowDto
{
    public string WorkInterval { get; set; }

    public int PlanQTY { get; set; }
    public int PlanCumulative { get; set; }

    public int FactQTY { get; set; }
    public int FactCumulative { get; set; }

    public int Deviation { get; set; }
    public int DeviationCumulative { get; set; }

    public int DowntimeMinutes { get; set; }

    public string ResponsibleUserName { get; set; }
    public string ReasonGroupName { get; set; }
    public string ReasonName { get; set; }

    public string Comment { get; set; }
    public string TakenMeasures { get; set; }
}

namespace ProductionAnalysisBackend.Models;

public class Row
{
    public int Id { get; set; }
    public int PlanQTY { get; set; }
    public int PlanCumulative { get; set; }
    public int FactQTY { get; set; }
    public int FactCumulative { get; set; }
    public int DowntimeMinutes { get; set; }
    
    public int ProductionAnalysisId { get; set; }
    public ProductionAnalysis ProductionAnalysis { get; set; }
    public int WorkIntervalId  { get; set; }
    public WorkInterval WorkInterval { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public List<Deviation> Deviations { get; set; }
}
namespace ProductionAnalysisBackend.Models;

public class LongCycle
{
    public int Id { get; set; }
    
    public string OperationName { get; set; } = null!;
    public DateTime PlanStart { get; set; }
    public DateTime PlanEnd { get; set; }
    public DateTime ActualStart { get; set; }
    public DateTime ActualEnd { get; set; }
    public int DeviationMinutes { get; set; }
    
    public int AnalysisId { get; set; }
    public ProductionAnalysis ProductionAnalysis { get; set; } = null!;
}
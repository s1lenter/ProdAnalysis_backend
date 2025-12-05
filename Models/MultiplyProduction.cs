namespace ProductionAnalysisBackend.Models;

public class MultiplyProduction
{
    public int Id { get; set; }
    
    public int CycleTime { get; set; }
    public int DailyTempo { get; set; }
    public int ChangeOverTime { get; set; }
    
    public int AnalysisId { get; set; }
    public ProductionAnalysis ProductionAnalysis { get; set; } = null!;

    public List<Product> Products { get; set; }
}
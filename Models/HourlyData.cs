namespace ProductionAnalysisBackend.Models;

public class HourlyData
{
    public int Id { get; set; }
    
    public int HourInterval { get; set; }
    public int PlanQuantity { get; set; }
    public int ActualQuantity { get; set; }
    public int Deviation { get; set; }
    public int CumulativePlan { get; set; }
    public int CumulativeActual { get; set; }
    public int DowntimeMinutes { get; set; }
    
    public int AnalysisId { get; set; }
    public ProductionAnalysis ProductionAnalysis { get; set; } = null!;

}
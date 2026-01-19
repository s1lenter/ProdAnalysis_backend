namespace ProductionAnalysisBackend.Models;

public class CycleOperation
{
    public int Id { get; set; }

    public int ProductionCycleAnalysisId { get; set; }
    public ProductionCycleAnalysis ProductionCycleAnalysis { get; set; }

    public string Name { get; set; }
    public int DurationMinutes { get; set; }

    /// <summary>
    /// План (обычно 1)
    /// </summary>
    public int PlanQty { get; set; }

    /// <summary>
    /// Порядок выполнения
    /// </summary>
    public int Order { get; set; }
    
    public int? FactDurationMinutes { get; set; }
    public string? Comment { get; set; }
}
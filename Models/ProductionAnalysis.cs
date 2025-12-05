namespace ProductionAnalysisBackend.Models;

public class ProductionAnalysis
{
    public int Id { get; set; }
    public int ScenarioId { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int EquipmentId { get; set; }
    public int ShiftId { get; set; }
    public int ReasonId { get; set; }
    
    public DateTime WorkDate { get; set; }
    public int PlanQuantity { get; set; }
    public int ActualQuantity { get; set; }
    public int DowntimeMinutes { get; set; }
    public string TakenMeasures { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    
    
}
namespace ProductionAnalysisBackend.Models;

public class Deviation
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public string TakenMeasures { get; set; }
    public int Value { get; set; }
    
    public int RowId { get; set; }
    public Row Row { get; set; }
    public int ReasonGroupId { get; set; }
    public ReasonGroup ReasonGroup { get; set; }
    public int ReasonId { get; set; }
    public Reason Reason { get; set; }
    public int ResponsibleUserId { get; set; }
    public User User { get; set; }
}
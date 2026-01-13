namespace ProductionAnalysisBackend.Models;

public class Reason
{
    public int Id { get; set; }
    public string Description { get; set; }
    
    public int GroupId { get; set; }
    public ReasonGroup ReasonGroup { get; set; }
    
    public List<Deviation> Deviations { get; set; }
    
}
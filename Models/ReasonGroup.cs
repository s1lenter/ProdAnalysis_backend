namespace ProductionAnalysisBackend.Models;

public class ReasonGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Reason> Reasons { get; set; }
    public List<Deviation> PADeviations { get; set; }
    
}
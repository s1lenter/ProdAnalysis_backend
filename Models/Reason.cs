namespace ProductionAnalysisBackend.Models;

public class Reason
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;

    public int GroupId { get; set; }
    public ReasonGroup ReasonGroup { get; set; } = null!;

    public List<Deviation> Deviations { get; set; } = new();
}

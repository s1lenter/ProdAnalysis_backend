namespace ProductionAnalysisBackend.Models;

public class ReasonGroup : IDictionaryEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<Reason> Reasons { get; set; } = new();
    public List<Deviation> Deviations { get; set; } = new();
}
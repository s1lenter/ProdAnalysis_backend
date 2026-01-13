namespace ProductionAnalysisBackend.Models;

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public int AuthorId { get; set; }
    public User Author { get; set; }
    public int ProductionAnalysisId { get; set; }
    public ProductionAnalysis ProductionAnalysis { get; set; }
}
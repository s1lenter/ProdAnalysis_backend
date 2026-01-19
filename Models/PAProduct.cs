namespace ProductionAnalysisBackend.Models;

public class PAProduct
{
    public int Id { get; set; }
    public int ProductionAnalysisId { get; set; }
    public int ProductId { get; set; }
    public ProductionAnalysis  ProductionAnalysis { get; set; }
    public Product Product { get; set; }
}
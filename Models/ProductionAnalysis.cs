namespace ProductionAnalysisBackend.Models;

public class ProductionAnalysis
{
    public int Id { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime SendToReviewAt { get; set; }
    public DateTime ApprovedAt { get; set; }
    
    public int ShiftId  { get; set; }
    public Shift Shift { get; set; }
    public int ScenarioId  { get; set; }
    public Scenario Scenario { get; set; }
    public int DepartmentId  { get; set; }
    public Department Department { get; set; }
    public int OperatorId { get; set; }
    public User Operator { get; set; }
    public int CreatorId { get; set; }
    
    // public int ProductId { get; set; }
    // public Product Product { get; set; }
    
    public List<PAProduct> Products { get; set; }
    
    public List<Parameter> Parameters { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Row> Rows { get; set; }
}
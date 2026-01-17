namespace ProductionAnalysisBackend.Models;

public class User : IDictionaryEntity
{
    public int Id { get; set; }
    public string PersonalKey { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    
    public string Role { get; set; }
    
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    
    public List<ProductionAnalysis>  ProductionAnalyses { get; set; }
    public List<Shift> Shifts { get; set; }
    public List<Comment> Comments { get; set; }
}
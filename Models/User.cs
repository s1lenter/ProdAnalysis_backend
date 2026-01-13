namespace ProductionAnalysisBackend.Models;

public class User
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    public string PersonalKey { get; set; }
    public string Email { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public int RoleId  { get; set; }
    public Role Role { get; set; }
    public int DepartamentId { get; set; }
    public Department Departament { get; set; }
    
    public List<ProductionAnalysis>  ProductionAnalyses { get; set; }
    public List<Shift> Shifts { get; set; }
    public List<Comment> Comments { get; set; }
}
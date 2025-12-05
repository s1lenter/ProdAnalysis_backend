namespace ProductionAnalysisBackend.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<Equipment> Equipments { get; set; }
    public List<User> Users { get; set; }
}
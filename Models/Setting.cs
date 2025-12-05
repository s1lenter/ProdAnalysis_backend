namespace ProductionAnalysisBackend.Models;

public class Setting
{
    public int Id { get; set; }
    
    public int LunchBreakMinutes { get; set; }
    public int ChangeoverMinutes { get; set; }
    public int CleaningMinutes { get; set; }
    
    public int ScenarioId { get; set; }
    public Scenario Scenario { get; set; }
    
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}
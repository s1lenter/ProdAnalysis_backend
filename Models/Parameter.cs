using System.Diagnostics.CodeAnalysis;

namespace ProductionAnalysisBackend.Models;

public class Parameter
{
    public int Id { get; set; }
    public int TaktTimeSec { get; set; }
    public int CycleTimeSec { get; set; }
    public int DailyTarget { get; set; }
    public int PowerPerHour { get; set; }
    public int LunchBreakMinutes { get; set; }
    public int ChangeOverMinutes { get; set; }
    public int CleaningMinutes { get; set; }
    
    public int ProductionAnalysisId { get; set; }
    public ProductionAnalysis ProductionAnalysis { get; set; }
}
namespace ProductionAnalysisBackend.Dto.Tables;

public class ProductionAnalysisTableDto
{
    // ===== ШАПКА =====
    public string ProductName { get; set; }
    public string DepartmentName { get; set; }
    public string FilledBy { get; set; }
    public string ShiftInfo { get; set; }

    public int PowerPerHour { get; set; }
    public int DailyTarget { get; set; }

    // ===== СТРОКИ =====
    public List<ProductionAnalysisRowDto> Rows { get; set; }
}
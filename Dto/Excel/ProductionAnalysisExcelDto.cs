namespace ProductionAnalysisBackend.Dto.Excel;

public class ProductionAnalysisExcelDto
{
    public string ProductName { get; set; }
    public string DepartmentName { get; set; }
    public string FilledBy { get; set; }
    public string ShiftInfo { get; set; }

    public int? PowerPerHour { get; set; }
    public int? TaktTime { get; set; }
    public int DailyTarget { get; set; }

    public List<ProductionAnalysisExcelRowDto> Rows { get; set; }
}
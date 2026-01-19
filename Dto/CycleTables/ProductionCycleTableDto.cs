namespace ProductionAnalysisBackend.Dto.CycleTables;

public class ProductionCycleTableDto
{
    public int AnalysisId { get; set; }

    public string ProductName { get; set; }
    public string DepartmentName { get; set; }
    public string OperatorName { get; set; }

    public DateTime Date { get; set; }
    public int CycleTimeMinutes { get; set; }

    public List<CycleOperationRowDto> Rows { get; set; }
}
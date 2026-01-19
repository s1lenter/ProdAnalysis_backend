namespace ProductionAnalysisBackend.Dto.CycleTables;

public class CycleAnalysisCreateDto
{
    public int ProductId { get; set; }
    public int DepartmentId { get; set; }
    public int OperatorId { get; set; }

    public DateTime Date { get; set; }

    /// <summary>
    /// Общее время цикла (мин)
    /// </summary>
    public int CycleTimeMinutes { get; set; }

    public List<CycleOperationCreateDto> Operations { get; set; }
}
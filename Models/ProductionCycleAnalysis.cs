namespace ProductionAnalysisBackend.Models;

public class ProductionCycleAnalysis
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public int OperatorId { get; set; }
    public User Operator { get; set; }

    public DateTime Date { get; set; }

    /// <summary>
    /// Время изготовления одной единицы, мин
    /// </summary>
    public int CycleTimeMinutes { get; set; }

    public List<CycleOperation> Operations { get; set; }
}
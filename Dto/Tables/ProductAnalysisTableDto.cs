namespace ProductionAnalysisBackend.Dto.Tables;

public class ProductAnalysisTableDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }

    public List<ProductAnalysisRowDto> Rows { get; set; }
}
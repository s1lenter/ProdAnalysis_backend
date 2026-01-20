namespace ProductionAnalysisBackend.Dto.Tables;

public class UpdateTableDto
{
    public string TableId { get; set; }
    public List<UpdateRowDto> Rows { get; set; }
}
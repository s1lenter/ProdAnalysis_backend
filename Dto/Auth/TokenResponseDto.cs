namespace ProductionAnalysisBackend.Dto;

public class TokenResponseDto
{
    public int Id  { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string Role { get; set; }
}
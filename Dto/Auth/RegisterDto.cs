namespace ProductionAnalysisBackend.Dto;

public class RegisterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public string PersonalKey { get; set; }
    public string Password { get; set; }
    //непонятно что вообще с этим ключом, надо об этом поговорить, подумать
}
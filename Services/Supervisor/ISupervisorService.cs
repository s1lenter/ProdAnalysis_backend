using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Dto.Supervisor;

namespace ProductionAnalysisBackend.Services.Supervisor;

public interface ISupervisorService
{
    public Task<Result<List<ShiftDto>>> GetAsync();
    public Task<Result<string>> CreateShiftAsync(ShiftCreateDto shiftCreateDto);
}
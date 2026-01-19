using ProductionAnalysisBackend.Dto;
using ProductionAnalysisBackend.Dto.Supervisor;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Services.Supervisor;

public interface ISupervisorService
{
    public Task<Result<ShiftDto>> GetAsync();
    public Task<Result<string>> CreateShiftAsync(ShiftCreateDto shiftCreateDto);
    Task<List<UserDto>> GetByDepartment(int departmentId);
    Task CloseShiftAsync(int shiftId);
}
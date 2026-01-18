using ProductionAnalysisBackend.Dto.Supervisor;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Supervisor;

public interface ISupervisorRepository
{
    public Task CreateShiftAsync(Shift shift);
    public Task<Department> GetDepartmentAsync(int departmentId);
    public Task<int> GetOperatorIdAsync(int operatorId);
    public Task<List<Shift>> GetAsync(int userId);
}
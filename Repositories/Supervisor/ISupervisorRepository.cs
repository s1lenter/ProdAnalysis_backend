using ProductionAnalysisBackend.Dto.Supervisor;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Supervisor;

public interface ISupervisorRepository
{
    public Task CreateShiftAsync(Shift shift);
    public Task<Department> GetDepartmentAsync(int departmentId);
    public Task<User> GetOperatorAsync(int operatorId);
    public Task<int> GetOperatorIdAsync(int operatorId);
    public Task<Shift> GetByUserAsync(int userId);
    public Task<Shift> GetAsync(int shiftId);
    Task<List<User>> GetByDepartmentId(int departmentId);
    public Task CloseShiftAsync(Shift shift);
}
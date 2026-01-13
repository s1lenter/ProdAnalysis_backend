using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Supervizor;

public interface ISupervizorRepository
{
    public Task CreateShiftAsync(Shift shift);
    public Task<Department> GetDepartmentAsync(int departmentId);
    public Task<int> GetOperatorIdAsync(int operatorId);
}
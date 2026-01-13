using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Supervizor;

public class SupervizorRepository : ISupervizorRepository
{
    private readonly AppDbContext _context;
    public SupervizorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateShiftAsync(Shift shift)
    {
        await _context.Shifts.AddAsync(shift);
        await _context.SaveChangesAsync();
    }

    public async Task<Department> GetDepartmentAsync(int departmentId)
    {
        return await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);
    }

    public async Task<int> GetOperatorIdAsync(int operatorId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == operatorId);
        return user.Id;
    }
}
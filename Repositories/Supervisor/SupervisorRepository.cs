using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Dto.Supervisor;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend.Repositories.Supervisor;

public class SupervisorRepository : ISupervisorRepository
{
    private readonly AppDbContext _context;
    public SupervisorRepository(AppDbContext context)
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

    public async Task<List<Shift>> GetAsync(int userId)
    {
        var shifts = await _context.Shifts.Where(s => s.CreatorId == userId)
            .OrderByDescending(s => s.Date).ToListAsync();
        return shifts;
    }
    
    public async Task<List<User>> GetByDepartmentId(int departmentId)
    {
        return await _context.Users
            .Where(u => u.DepartmentId == departmentId)
            .OrderBy(u => u.LastName)
            .ToListAsync();
    }
}
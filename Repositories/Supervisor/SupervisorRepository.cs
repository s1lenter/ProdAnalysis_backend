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

    public async Task<User> GetOperatorAsync(int operatorId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == operatorId);
        if (user == null)
            throw new NullReferenceException("User not found");
        return user;
    }
    
    public async Task<int> GetOperatorIdAsync(int operatorId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == operatorId);
        if (user == null)
            throw new NullReferenceException("User not found");
        return user.Id;
    }

    public async Task<Shift> GetAsync(int userId)
    {
        return await _context.Shifts.FirstOrDefaultAsync(s => s.CreatorId == userId && s.Status != "Closed");
    }
    
    public async Task<List<User>> GetByDepartmentId(int departmentId)
    {
        return await _context.Users
            .Where(u => u.DepartmentId == departmentId)
            .OrderBy(u => u.LastName)
            .ToListAsync();
    }

    public async Task CloseShiftAsync(Shift shift)
    {
        _context.Shifts.Update(shift);
        await _context.SaveChangesAsync();
    }
}
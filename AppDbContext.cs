using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DownTimeReason> DownTimeReasons { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<HourlyData> HourlyDates { get; set; }
    public DbSet<LongCycle> LongCycles { get; set; }
    public DbSet<MultiplyProduction> MultiplyProductions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductionAnalysis> ProductionAnalyses { get; set; }
    public DbSet<Scenario> Scenarios { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<WorkInterval> WorkIntervals { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
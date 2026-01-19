using Microsoft.EntityFrameworkCore;
using ProductionAnalysisBackend.Models;

namespace ProductionAnalysisBackend;

public class AppDbContext : DbContext
{
    // ===== Основные таблицы =====
    public DbSet<Row> Rows { get; set; }
    public DbSet<Deviation> Deviations { get; set; }
    public DbSet<ProductionAnalysis> ProductionAnalyses { get; set; }
    public DbSet<PAProduct> PAProducts { get; set; }
    public DbSet<Product> Products { get; set; }

    // ===== Причины простоев =====
    public DbSet<ReasonGroup> ReasonGroups { get; set; }
    public DbSet<Reason> Reasons { get; set; }

    // ===== Пользователи и справочники =====
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<WorkInterval> WorkIntervals { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Scenario> Scenarios { get; set; }

    // ===== Прочее =====
    public DbSet<Parameter> Parameters { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    public DbSet<ProductionCycleAnalysis> ProductionCycleAnalyses { get; set; }
    public DbSet<CycleOperation> CycleOperations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // =========================
        // Row → Deviations (1 → many)
        // =========================
        modelBuilder.Entity<Deviation>()
            .HasOne(d => d.Row)
            .WithMany(r => r.Deviations)
            .HasForeignKey(d => d.RowId)
            .OnDelete(DeleteBehavior.Cascade);

        // =========================
        // ReasonGroup → Reasons
        // =========================
        modelBuilder.Entity<Reason>()
            .HasOne(r => r.ReasonGroup)
            .WithMany(g => g.Reasons)
            .HasForeignKey(r => r.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // =========================
        // Reason → Deviations
        // =========================
        modelBuilder.Entity<Deviation>()
            .HasOne(d => d.Reason)
            .WithMany(r => r.Deviations)
            .HasForeignKey(d => d.ReasonId)
            .OnDelete(DeleteBehavior.Restrict);

        // =========================
        // ReasonGroup → Deviations
        // =========================
        modelBuilder.Entity<Deviation>()
            .HasOne(d => d.ReasonGroup)
            .WithMany(g => g.Deviations)
            .HasForeignKey(d => d.ReasonGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // =========================
        // User → Deviations (responsible)
        // =========================
        modelBuilder.Entity<Deviation>()
            .HasOne(d => d.ResponsibleUser)
            .WithMany()
            .HasForeignKey(d => d.ResponsibleUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // =========================
        // ProductionAnalysis → Rows
        // =========================
        modelBuilder.Entity<Row>()
            .HasOne(r => r.ProductionAnalysis)
            .WithMany(pa => pa.Rows)
            .HasForeignKey(r => r.ProductionAnalysisId)
            .OnDelete(DeleteBehavior.Cascade);

        // =========================
        // Product → Rows
        // =========================
        modelBuilder.Entity<Row>()
            .HasOne(r => r.Product)
            .WithMany(p => p.Rows)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // =========================
        // WorkInterval → Rows
        // =========================
        modelBuilder.Entity<Row>()
            .HasOne(r => r.WorkInterval)
            .WithMany()
            .HasForeignKey(r => r.WorkIntervalId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ProductionCycleAnalysis>()
            .HasMany(p => p.Operations)
            .WithOne(o => o.ProductionCycleAnalysis)
            .HasForeignKey(o => o.ProductionCycleAnalysisId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

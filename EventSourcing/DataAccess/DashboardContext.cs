using EventSourcing.Models;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.DataAccess;

public class DashboardContext : DbContext
{
    public DashboardContext(DbContextOptions<DashboardContext> options) : base(options)
    {
        
    }

    public DbSet<DashboardEvent> DashboardEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DashboardEvent>()
            .ToTable(nameof(DashboardEvent))
            .HasKey(e => e.EventId);
    }
}
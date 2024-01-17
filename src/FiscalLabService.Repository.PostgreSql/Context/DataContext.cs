using FiscalLabService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class DataContext : DbContext
{
    public DbSet<Plant> Plants { get; set; }
    
    public DataContext(
        DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlantConfig());
        modelBuilder.ApplyConfiguration(new PlantEmailConfig());
        base.OnModelCreating(modelBuilder);
    }
}
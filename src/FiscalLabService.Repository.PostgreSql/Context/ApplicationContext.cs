using FiscalLabService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Association> Associations { get; set; }
    public DbSet<Menu> Menus { get; set; }
    
    public ApplicationContext(
        DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlantConfig());
        modelBuilder.ApplyConfiguration(new AssociationConfig());
        modelBuilder.ApplyConfiguration(new MenuConfig());
        base.OnModelCreating(modelBuilder);
    }
}
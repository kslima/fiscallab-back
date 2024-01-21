using FiscalLabService.Domain.Entities;
using FiscalLabService.Repository.PostgreSql.Resources;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Association> Associations { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<VisitPage> VisitPages { get; set; }

    private readonly SeedDataOptions _seedDataOptions;
    
    public ApplicationContext(
        DbContextOptions<ApplicationContext> options,
        SeedDataOptions seedDataOptions) : base(options)
    {
        _seedDataOptions = seedDataOptions;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlantConfig());
        modelBuilder.ApplyConfiguration(new AssociationConfig());
        modelBuilder.ApplyConfiguration(new MenuConfig());
        modelBuilder.ApplyConfiguration(new VisitPageConfig(_seedDataOptions));
        base.OnModelCreating(modelBuilder);
    }
}
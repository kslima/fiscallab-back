using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FiscalLabService.Repository.PostgreSql.Context;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<DataContext>()
            .UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=fiscal-lab",
                b => b.MigrationsAssembly("FiscalLabService.Repository.PostgreSql"));
 
        return new DataContext(builder.Options);
    }
}
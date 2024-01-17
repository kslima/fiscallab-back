// using FiscalLabService.Repository.SqLite.Context;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
//
// namespace FiscalLabService.API.Factory;
//
// public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
// {
//     public DataContext CreateDbContext(string[] args)
//     {
//         var configuration = new ConfigurationBuilder()
//             .SetBasePath(Directory.GetCurrentDirectory())
//             .AddJsonFile("appsettings.json")
//             .Build();
//
//         var connectionString = configuration.GetConnectionString("SqLiteOptions:ConnectionString");
//         var builder = new DbContextOptionsBuilder<DataContext>()
//             .UseSqlite("Data Source=FiscalLab.db");
//         
//         return new DataContext(builder.Options);
//     }
// }
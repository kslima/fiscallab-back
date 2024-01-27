using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Repositories;

public class VisitRepository(ApplicationContext context) : IVisitRepository
{
    public async Task<Visit> CreateAsync(Visit visit)
    {
        await context.Visits.AddAsync(visit);
        await context.SaveChangesAsync();
        return await GetById(visit.Id);
    }
    
    private async Task<Visit> GetById(string id)
    {
        return await context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .SingleAsync(v => v.Id.Equals(id));
    }

    public async Task<List<Visit>> ListAsync()
    {
        return await context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .ToListAsync();
    }
}
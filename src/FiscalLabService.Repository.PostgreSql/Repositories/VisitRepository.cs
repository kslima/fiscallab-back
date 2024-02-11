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

    public async Task<List<Visit>> CreateManyAsync(List<Visit> visits)
    {
        // visits.ForEach(x =>
        // {
        //     var association = context.Associations.Local.FirstOrDefault(v => v.Id.Equals(x.BasicInformation.AssociationId));
        //     if (association is not null)
        //     {
        //         context.Entry(association).State = EntityState.Detached;
        //     }
        //     
        //     var plant = context.Plants.Local.FirstOrDefault(v => v.Id.Equals(x.BasicInformation.PlantId));
        //     if (plant is not null)
        //     {
        //         context.Entry(plant).State = EntityState.Detached;
        //     }
        // });
        await context.Visits.AddRangeAsync(visits);
        await context.SaveChangesAsync();
        return await GetByIds(visits.Select(x => x.Id).ToArray());
    }

    public async Task<List<Visit>> UpdateManyAsync(List<Visit> visits)
    {
        // visits.ForEach(x =>
        // {
        //     var any = context.Associations.Local.FirstOrDefault(v => v.Id.Equals(x.BasicInformation.AssociationId));
        //     if (any is not null)
        //     {
        //         context.Entry(any).State = EntityState.Detached;
        //     }
        // });
        context.Visits.UpdateRange(visits);
        await context.SaveChangesAsync();
        return visits;
    }

    private async Task<List<Visit>> GetByIds(string[] ids)
    {
        return await context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Where(v => ids.Contains(v.Id))
            .ToListAsync();
    }

    public async Task<Visit> GetById(string id)
    {
        return await context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .SingleAsync(v => v.Id.Equals(id));
    }

    public async Task<List<Visit>> GetByIdsAsync(string[] ids)
    {
        return await context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
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
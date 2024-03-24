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
        await context.Visits.AddRangeAsync(visits);
        await context.SaveChangesAsync();
        return await GetByIds(visits.Select(x => x.Id).ToArray());
    }

    public async Task<List<Visit>> UpdateManyAsync(List<Visit> visits)
    {
        var visitIds = visits.Select(p => p.Id);
        var visitsToUpdate = context.Visits
            .Where(p => visitIds.Contains(p.Id))
            .ToList();
        
        foreach (var visit in visitsToUpdate)
        {
            var updatedVisit = visits.First(x => x.Id.Equals(visit.Id));
            visit.BasicInformation = updatedVisit.BasicInformation;
            visit.SugarcaneBalance = updatedVisit.SugarcaneBalance;
            visit.DesintegratorProbe = updatedVisit.DesintegratorProbe;
            visit.AnalyticalBalance = updatedVisit.AnalyticalBalance;
            visit.PressRefractometer = updatedVisit.PressRefractometer;
            visit.ClarificationSaccharimeter = updatedVisit.ClarificationSaccharimeter;
            visit.BenchmarkingEquipment = updatedVisit.BenchmarkingEquipment;
            visit.SystemConsistency = updatedVisit.SystemConsistency;
            visit.Conclusion = updatedVisit.Conclusion;
            visit.FinishedAt = updatedVisit.FinishedAt;
            visit.Images = updatedVisit.Images;
            visit.BalanceTests = updatedVisit.BalanceTests;
            
            visit.SyncedAt = DateTime.UtcNow;

            if (visit.NotifiedByEmailAt is not null) continue;
            
            visit.NotifyByEmail = updatedVisit.NotifyByEmail;
        }
        
        context.Visits.UpdateRange(visitsToUpdate);
        await context.SaveChangesAsync();
        return visitsToUpdate;
    }

    public async Task DeleteManyAsync(List<Visit> visits)
    {
        var visitIds = visits.Select(p => p.Id);
        var visitsToDelete = context.Visits
            .Where(p => visitIds.Contains(p.Id))
            .ToList();
        context.Visits.RemoveRange(visitsToDelete);
        await context.SaveChangesAsync();
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

    public async Task MarkAsSentByEmail(string id)
    {
        var visit = context.Visits
            .Single(p => p.Id.Equals(id));

        visit.NotifiedByEmailAt = DateTime.UtcNow;
        
        context.Visits.Update(visit);
        await context.SaveChangesAsync();
    }

    public async Task<List<Visit>> GetAllMarkedForMailing()
    {
        return await context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Include(v => v.Images)
            .Include(v => v.BalanceTests)
            .Where(x => x.NotifyByEmail)
            .Where(x => x.NotifiedByEmailAt == null)
            .ToListAsync();
    }

    public async Task<List<Visit>> GetByIdsAsync(string[] ids)
    {
        return await context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Include(v => v.Images)
            .Include(v => v.BalanceTests)
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
    }

    public async Task<List<Visit>> ListAsync()
    {
        return await context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Include(v => v.Images)
            .Include(v => v.BalanceTests)
            .ToListAsync();
    }
}
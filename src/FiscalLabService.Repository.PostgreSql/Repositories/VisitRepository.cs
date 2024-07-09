using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Enums;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Domain.Models;
using FiscalLabService.Repository.PostgreSql.Context;
using FiscalLabService.Repository.PostgreSql.Extensions;
using FiscalLabService.Repository.PostgreSql.Resources;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Repositories;

public class VisitRepository : IVisitRepository
{
    private readonly ApplicationContext _context;
    private readonly VisitOptions _visitOptions;
    public VisitRepository(
        ApplicationContext context,
        VisitOptions visitOptions)
    {
        _context = context;
        _visitOptions = visitOptions;
    }

    public async Task<Visit> CreateAsync(Visit visit)
    {
        await _context.Visits.AddAsync(visit);
        await _context.SaveChangesAsync();
        return await GetById(visit.Id);
    }

    public async Task<List<Visit>> CreateManyAsync(List<Visit> visits)
    {
        await _context.Visits.AddRangeAsync(visits);
        await _context.SaveChangesAsync();
        return await GetByIds(visits.Select(x => x.Id).ToArray());
    }

    public async Task<List<Visit>> UpdateManyAsync(List<Visit> visits)
    {
        var visitIds = visits.Select(p => p.Id);
        var visitsToUpdate = _context.Visits
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
            visit.BalanceTests = updatedVisit.BalanceTests;
            visit.SyncedAt = DateTime.UtcNow;
            visit.UpdatedAt = DateTime.UtcNow;
            visit.NotifyByEmail = updatedVisit.NotifyByEmail;
        }
        
        _context.Visits.UpdateRange(visitsToUpdate);
        await _context.SaveChangesAsync();
        return visitsToUpdate;
    }

    public async Task DeleteManyAsync(List<Visit> visits)
    {
        var visitIds = visits.Select(p => p.Id);
        var visitsToDelete = _context.Visits
            .Where(p => visitIds.Contains(p.Id))
            .ToList();
        _context.Visits.RemoveRange(visitsToDelete);
        await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeleteAsync(string id)
    {
        var visit = await _context.Visits
            .SingleAsync(x => x.Id.Equals(id));
         _context.Visits.Remove(visit);
        return await _context.SaveChangesAsync();
    }

    private async Task<List<Visit>> GetByIds(string[] ids)
    {
        return await _context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Where(v => ids.Contains(v.Id))
            .ToListAsync();
    }

    public async Task<Visit> GetById(string id)
    {
        return await _context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .SingleAsync(v => v.Id.Equals(id));
    }

    public async Task MarkAsSentByEmail(string id)
    {
        var visit = _context.Visits
            .Single(p => p.Id.Equals(id));

        visit.Status = VisitStatus.Done;
        visit.NotifiedByEmailAt = DateTime.UtcNow;
        visit.UpdatedAt = DateTime.UtcNow;
        
        _context.Visits.Update(visit);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Visit>> GetAllMarkedForMailing()
    {
        return await _context.Visits
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Include(v => v.BalanceTests)
            .Where(x => x.NotifyByEmail)
            .Where(x => x.NotifiedByEmailAt == null)
            .ToListAsync();
    }

    public async Task<List<Visit>> GetByIdsAsync(string[] ids)
    {
        return await _context.Visits
            .AsNoTracking()
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Include(v => v.BalanceTests)
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
    }

    public async Task<List<Visit>> ListAsync()
    {
        return await _context.Visits
            .AsNoTracking()
            .Where(v => v.Status != VisitStatus.Done)
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Include(v => v.BalanceTests)
            .OrderByDescending(x => x.CreatedAt)
            .Take(_visitOptions.DefaultPageSize)
            .ToListAsync();
    }

    public async Task<PagedList<Visit>> ListAsync(VisitParameters parameters)
    {
        var query = _context.Visits
            .AsNoTracking();
        
        if (parameters.Status is not null)
        {
            query = query
                .Where(s => s.Status == parameters.Status);
        }
        
        return await query
            .Include(v => v.BasicInformation.Plant)
            .Include(v => v.BasicInformation.Association)
            .Include(v => v.BalanceTests)
            .OrderByDescending(s => s.CreatedAt)
            .ExecutePagedQueryAsync(parameters);
    }
}
using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Repositories;

public class AssociationRepository : IAssociationRepository
{
    private readonly ApplicationContext _context;
    public AssociationRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Association>> CreateManyAsync(List<Association> associations)
    {
        await _context.Associations.AddRangeAsync(associations);
        await _context.SaveChangesAsync();
        return associations;
    }

    public async Task<List<Association>> UpdateManyAsync(List<Association> associations)
    {
        var associationsToUpdateIds = associations.Select(p => p.Id);

        var associationsToUpdate = _context.Associations
            .Where(p => associationsToUpdateIds.Contains(p.Id))
            .ToList();
        
        foreach (var association in associationsToUpdate)
        {
            var updatedPlant = associations.First(p => p.Id.Equals(association.Id));
            association.Name = updatedPlant.Name;
            association.Address = updatedPlant.Address;
            association.Emails = updatedPlant.Emails;
        }
        
        _context.Associations.UpdateRange(associationsToUpdate);
        await _context.SaveChangesAsync();
        return associationsToUpdate;
    }

    public async Task<List<Association>> GetByIdsAsync(List<string> ids)
    {
        return await _context.Associations
            .AsNoTracking()
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
    }

    public async Task<List<Association>> GetAllAsync()
    {
        return await _context.Associations
            .AsNoTracking()
            .ToListAsync();
    }
}
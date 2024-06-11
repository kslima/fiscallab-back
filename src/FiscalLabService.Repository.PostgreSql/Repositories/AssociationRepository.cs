using System.Linq.Expressions;
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

    public async Task<Association> CreateAsync(Association association)
    {
        await _context.Associations.AddAsync(association);
        await _context.SaveChangesAsync();
        return association;
    }

    public Task<bool> ExistsAsync(Expression<Func<Association, bool>> predicate)
    {
        return _context.Associations
            .AnyAsync(predicate);
    }

    public async Task<List<Association>> CreateManyAsync(List<Association> associations)
    {
        await _context.Associations.AddRangeAsync(associations);
        await _context.SaveChangesAsync();
        return associations;
    }

    public async Task<List<Association>> UpdateManyAsync(List<Association> associations)
    {
        var associationIds = associations.Select(p => p.Id);
        
        var associationsToUpdate = _context.Associations
            .AsNoTracking()
            .Where(p => associationIds.Contains(p.Id))
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

    public async Task<Association> UpdateAsync(string id, Association association)
    {
        var associationToUpdate = await _context.Associations
            .AsNoTracking()
            .Where(p => p.Id.Equals(id))
            .SingleAsync();
        
        associationToUpdate.Name = association.Name;
        associationToUpdate.Address.City = association.Address.City;
        associationToUpdate.Address.State = association.Address.State;
        associationToUpdate.Emails = association.Emails;
        
        _context.Associations.Update(associationToUpdate);
        await _context.SaveChangesAsync();
        return associationToUpdate;
    }

    public async Task<List<Association>> GetByIdsAsync(List<string> ids)
    {
        return await _context.Associations
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
    }

    public async Task<int> DeleteAsync(string id)
    {
        var association = await _context.Associations
            .SingleAsync(x => x.Id.Equals(id));
        _context.Associations.Remove(association);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<Association>> ListAsync()
    {
        return await _context.Associations
            .AsNoTracking()
            .ToListAsync();
    }
}
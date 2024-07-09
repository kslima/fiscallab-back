using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly ApplicationContext _context;

    public ImageRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task CreateManyAsync(List<Image> images)
    {
        await _context.Images.AddRangeAsync(images);
        await _context.SaveChangesAsync();
    }
    
    public async Task ReplaceAllAsync(string visitId, List<Image> images)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var imagesToDelete = await _context.Images
                .Where(x => x.VisitId.Equals(visitId))
                .ToListAsync();

            _context.Images.RemoveRange(imagesToDelete);
            await _context.Images.AddRangeAsync(images);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<Image> GetByIdAsync(string id)
    {
        return await _context.Images
            .AsNoTracking()
            .Where(p => id.Equals(p.Id))
            .SingleAsync();
    }
    
    public async Task<List<Image>> GetByIdsAsync(string[] ids)
    {
        return await _context.Images
            .AsNoTracking()
            .Where(v => ids.Contains(v.Id))
            .ToListAsync();
    }

    public async Task<int> DeleteAsync(string visitId, string id)
    {
        var image = await _context.Images
            .Where(x => x.VisitId.Equals(visitId))
            .SingleAsync(x => x.Id.Equals(id));
        _context.Images.Remove(image);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<Image>> ListByVisitAsync(string visitId)
    {
        return await _context.Images
            .AsNoTracking()
            .Where(i => i.VisitId.Equals(visitId))
            .ToListAsync();
    }
    
    public async Task<List<Image>> ListByVisitsAsync(List<string> visitIds)
    {
        return await _context.Images
            .AsNoTracking()
            .Where(i => visitIds.Contains(i.VisitId))
            .ToListAsync();
    }
}
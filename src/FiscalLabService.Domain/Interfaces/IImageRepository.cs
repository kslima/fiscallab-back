using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IImageRepository
{
    Task CreateManyAsync(List<Image> images);
    Task<Image> GetByIdAsync(string id);
    Task<int> DeleteAsync(string visitId, string id);
    Task<List<Image>> GetByIdsAsync(string[] ids);
    Task ReplaceAllAsync(string visitId, List<Image> images);
    Task<List<Image>> ListByVisitAsync(string visitId);
    Task<List<Image>> ListByVisitsAsync(List<string> visitIds);
}
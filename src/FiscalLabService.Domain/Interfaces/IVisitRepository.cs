using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Models;

namespace FiscalLabService.Domain.Interfaces;

public interface IVisitRepository
{
    Task<Visit> CreateAsync(Visit visit);
    Task<List<Visit>> CreateManyAsync(List<Visit> visits);
    Task<List<Visit>> UpdateManyAsync(List<Visit> visits);
    Task<int> DeleteAsync(string id);
    Task DeleteManyAsync(List<Visit> visits);
    Task<Visit> GetById(string id);
    Task MarkAsSentByEmail(string id);
    Task<List<Visit>> GetAllMarkedForMailing();
    Task<List<Visit>> GetByIdsAsync(string[] ids);
    Task<List<Visit>> ListAsync();
    Task<PagedList<Visit>> ListAsync(VisitParameters parameters);
}
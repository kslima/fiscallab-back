using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IVisitRepository
{
    Task<Visit> CreateAsync(Visit visit);
    Task<List<Visit>> CreateManyAsync(List<Visit> visits);
    Task<List<Visit>> UpdateManyAsync(List<Visit> visits);
    Task<Visit> GetById(string id);
    Task<List<Visit>> GetByIdsAsync(string[] ids);
    Task<List<Visit>> ListAsync();
}
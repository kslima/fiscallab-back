using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IVisitRepository
{
    Task<Visit> CreateAsync(Visit visit);
    Task<Visit> GetById(string id);
    Task<List<Visit>> ListAsync();
}
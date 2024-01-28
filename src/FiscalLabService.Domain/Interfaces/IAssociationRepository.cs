using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IAssociationRepository
{
    Task<List<Association>> CreateManyAsync(List<Association> associations);
    Task<List<Association>> UpdateManyAsync(List<Association> associations);
    Task<List<Association>> GetByIdsAsync(List<string> ids);
    Task<List<Association>> ListAsync();
}
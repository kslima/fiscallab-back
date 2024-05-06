using System.Linq.Expressions;
using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IAssociationRepository
{
    Task<Association> CreateAsync(Association association);
    Task<bool> ExistsAsync(Expression<Func<Association, bool>> predicate);
    Task<List<Association>> CreateManyAsync(List<Association> associations);
    Task<List<Association>> UpdateManyAsync(List<Association> associations);
    Task<Association> UpdateAsync(string id, Association association);
    Task<List<Association>> GetByIdsAsync(List<string> ids);
    Task<List<Association>> ListAsync();
}
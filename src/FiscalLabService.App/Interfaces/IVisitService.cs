using FiscalLabService.App.Dtos;
using FiscalLabService.App.Models;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IVisitService
{
    Task<Result<bool>> UpsertAsync(List<VisitModel> visitModels);
    Task<Result<VisitDto>> CreateAsync(VisitModel visitModel);
    Task<Result<bool>> CreateManyAsync(VisitModel[] visitModels);
    Task<Result<List<VisitDto>>> ListAsync();
    Task<Result<VisitDto>> GetByIdAsync(string id);
    Task<Result<bool>> DeleteAsync(string id);
}
using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Models;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IAssociationService
{
    Task<Result<CreateAssociationResponse>> CreateAsync(CreateAssociationRequest request);
    Task<Result<CreateAssociationResponse>> UpdateAsync(string id, CreateAssociationRequest request);
    Task<Result<UpsertAssociationsDto>> UpsertAsync(UpsertAssociationsModel model);
    Task<Result<List<AssociationDto>>> ListAsync();
}
using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Request;
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IPlantService
{
    Task<Result<CreatePlantResponse>> CreateAsync(CreatePlantRequest request);
    Task<Result<CreatePlantResponse>> UpdateAsync(string id, CreatePlantRequest request);
    Task<Result<bool>> DeleteAsync(string id);
    Task<Result<List<PlantDto>>> ListAsync();
}
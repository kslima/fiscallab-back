using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Interfaces;

public interface IImageService
{
    Task<Result<GetImageResponse>> GetByIdAsync(string id);
    Task<Result<bool>> DeleteAsync(string visitId, string id);
    Task<Result<List<GetImageResponse>>> ListByVisitAsync(string visitId);
    Task<Result<bool>> ReplaceImagesAsync(string visitId, List<ImageDto> images);
}
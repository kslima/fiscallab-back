using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.App.Extensions;
using FiscalLabService.App.Interfaces;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    
    public async Task<Result<bool>> ReplaceImagesAsync(string visitId, List<ImageDto> imagesDtos)
    {
        var images = imagesDtos.ToImages(visitId);
        await _imageRepository.ReplaceAllAsync(visitId, images);
        
        return Result<bool>.Success(true);
    }

    public async Task<Result<GetImageResponse>> GetByIdAsync(string id)
    {
        var image = await _imageRepository.GetByIdAsync(id);
        return Result<GetImageResponse>.Success(new GetImageResponse(image));
    }

    public async Task<Result<bool>> DeleteAsync(string visitId, string id)
    {
        var deleteResult = await _imageRepository.DeleteAsync(visitId, id);
        return deleteResult == 1
            ? Result<bool>.Success(true)
            : Result<bool>.Failure(new Error("delete_error", "error on delete."));
    }

    public async Task<Result<List<GetImageResponse>>> ListByVisitAsync(string visitId)
    {
        var images = await _imageRepository.ListByVisitAsync(visitId);
        return Result<List<GetImageResponse>>.Success(images.Select(i => new GetImageResponse(i)).ToList());
    }
}
using FiscalLabService.App.Dtos.Response;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Domain.Entities;

namespace FiscalLabService.App.Extensions;

public static class ImageExtensions
{
    public static List<Image> ToImages(this List<ImageDto> dtos, string visitId)
    {
        return dtos
            .Select(x => x.MapToImage(visitId))
            .ToList();
    }
    
    private static Image MapToImage(this ImageDto dto, string visitId)
    {
        return new Image
        {
            Id = dto.Id,
            VisitId = visitId,
            Name = dto.Name,
            Description = dto.Description,
            Data = dto.Data
        };
    }
    
    public static ImageDto MapToImageDto(this GetImageResponse dto)
    {
        return new ImageDto
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Data = dto.Data
        };
    }
    
    public static ImageDto MapToImage(this Image image)
    {
        return new ImageDto
        {
            Id = image.Id,
            VisitId = image.VisitId,
            Name = image.Name,
            Description = image.Description,
            Data = image.Data
        };
    }
}
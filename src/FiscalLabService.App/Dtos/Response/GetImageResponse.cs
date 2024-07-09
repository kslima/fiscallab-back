using FiscalLabService.Domain.Entities;

namespace FiscalLabService.App.Dtos.Response;

public class GetImageResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public byte[] Data { get; set; }

    public GetImageResponse(Image image)
    {
        Id = image.Id;
        Name = image.Name;
        Description = image.Description;
        Data = image.Data;
    }
}
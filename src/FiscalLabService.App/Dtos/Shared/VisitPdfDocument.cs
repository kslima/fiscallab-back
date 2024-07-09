using FiscalLabService.Domain.Entities;

namespace FiscalLabService.App.Dtos.Shared;

public class VisitPdfDocument
{
    public Visit Visit { get; set; } = null!;
    public List<Image> Images { get; set; } = [];
}
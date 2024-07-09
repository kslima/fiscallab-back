using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;
using FiscalLabService.Domain.Entities;

namespace FiscalLabService.App.Extensions;

public static class VisitPageExtensions
{
    public static VisitPageDto AsVisitPageDto(this VisitPage visitPage)
    {
        return new VisitPageDto
        {
            Id = visitPage.Id,
            Name = visitPage.Name,
            DisplayName = visitPage.DisplayName
        };
    }
}
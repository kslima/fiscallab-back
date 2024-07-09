using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;

namespace FiscalLabService.App.Models;

public class UpsertAssociationsModel
{
    public List<AssociationDto> Associations { get; set; } = [];
}
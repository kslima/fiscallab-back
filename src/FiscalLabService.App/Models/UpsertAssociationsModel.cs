using FiscalLabService.App.Dtos;

namespace FiscalLabService.App.Models;

public class UpsertAssociationsModel
{
    public List<AssociationDto> Associations { get; set; } = [];
}
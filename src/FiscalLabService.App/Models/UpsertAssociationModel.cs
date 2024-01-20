using FiscalLabService.App.Dtos;

namespace FiscalLabService.App.Models;

public class UpsertAssociationModel
{
    public List<AssociationDto> Associations { get; set; } = [];
}
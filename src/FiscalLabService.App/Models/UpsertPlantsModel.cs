using FiscalLabService.App.Dtos;
using FiscalLabService.App.Dtos.Shared;

namespace FiscalLabService.App.Models;

public class UpsertPlantsModel
{
    public List<PlantDto> Plants { get; set; } = [];
}
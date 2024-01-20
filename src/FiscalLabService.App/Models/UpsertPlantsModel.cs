using FiscalLabService.App.Dtos;

namespace FiscalLabService.App.Models;

public class UpsertPlantsModel
{
    public List<PlantDto> Plants { get; set; } = [];
}
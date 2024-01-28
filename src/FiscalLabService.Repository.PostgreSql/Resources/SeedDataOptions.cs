using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Repository.PostgreSql.Resources;

public class SeedDataOptions
{
    public List<VisitPage> VisitPages { get; set; } = [];
}
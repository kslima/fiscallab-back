using FiscalLabService.Domain.Entities;
using FiscalLabService.Domain.Interfaces;
using FiscalLabService.Repository.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Repository.PostgreSql.Repositories;

public class VisitPageRepository(ApplicationContext context) : IVisitPageRepository
{
    public async Task<List<VisitPage>> ListAsync()
    {
        return await context.VisitPages
            .AsNoTracking()
            .ToListAsync();
    }
}
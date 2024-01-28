using FiscalLabService.Domain.Entities;

namespace FiscalLabService.Domain.Interfaces;

public interface IVisitPageRepository
{
    Task<List<VisitPage>> ListAsync();
}
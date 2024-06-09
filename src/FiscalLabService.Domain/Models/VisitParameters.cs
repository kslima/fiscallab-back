using FiscalLabService.Domain.Enums;

namespace FiscalLabService.Domain.Models;

public class VisitParameters : AbstractParameters
{
    public VisitStatus? Status { get; set; }
}
using FiscalLabService.App.Extensions;
using FiscalLabService.Domain.Enums;
using FiscalLabService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.App.Dtos.Request;

public class VisitQueryParameters : AbstractQueryParameters
{
    [FromQuery]
    public VisitStatus? Status { get; set; }

    public VisitParameters AsVisitParameters()
    {
        var parameters = new VisitParameters
        {
            Status = Status
        };

        parameters.CopyPageParameters(this);

        return parameters;
    }
}
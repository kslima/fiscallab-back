using FiscalLabService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiscalLabService.App.Dtos.Request;

public class AbstractQueryParameters
{
    private const int MaxPageSize = 50;
    [FromQuery]
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 10;
    
    [FromQuery]
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
    
    [FromQuery]
    public string? SortBy { get; set; }
    
}
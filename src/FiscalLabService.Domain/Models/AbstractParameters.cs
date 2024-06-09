namespace FiscalLabService.Domain.Models;

public class AbstractParameters
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;
    public string? SortBy { get; set; }
    public bool SortAscending { get; set; } = true;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
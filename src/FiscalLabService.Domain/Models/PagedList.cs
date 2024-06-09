namespace FiscalLabService.Domain.Models;

public class PagedList<T> : List<T>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public long TotalCount { get; set; }
    public int TotalPages { get; set; }
    
    public PagedList(IEnumerable<T> items, long count, int pageIndex, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalPages = (int) Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }
}
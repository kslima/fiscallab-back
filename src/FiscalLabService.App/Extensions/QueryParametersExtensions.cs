using FiscalLabService.App.Dtos.Request;
using FiscalLabService.Domain.Models;
using FiscalLabService.Shared.Extensions;
using FiscalLabService.Shared.Responses;

namespace FiscalLabService.App.Extensions;

public static class QueryParametersExtensions
{
    public static Metadata AsMetadata<T>(this PagedList<T> pagedList)
    {
        return new Metadata
        {
            PageIndex = pagedList.PageIndex,
            PageSize = pagedList.PageSize,
            TotalCount = (int) pagedList.TotalCount,
            TotalPages = pagedList.TotalPages
        };
    }
    
    public static void CopyPageParameters(
        this AbstractParameters parameters,
        AbstractQueryParameters queryParameters)
    {
        parameters.PageIndex = queryParameters.PageIndex;
        parameters.PageSize = queryParameters.PageSize;
        parameters.SortBy = queryParameters.SortBy;
        
        if (string.IsNullOrWhiteSpace(queryParameters.SortBy)) return;
        
        var sortParameters = queryParameters.SortBy.Split(",");
        if (sortParameters.Length == 2)
        {
            parameters.SortAscending = sortParameters[1].Equals("asc");
            parameters.SortBy = sortParameters[0].ToCamelCase();
        }
        else
        {
            parameters.SortBy = queryParameters.SortBy;
        }
    }
}